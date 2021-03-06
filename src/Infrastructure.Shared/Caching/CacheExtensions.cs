﻿#region copyright

// Copyright 2013 Alphacloud.Net
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
// 
//        http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.

#endregion

namespace Alphacloud.Common.Infrastructure.Caching
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Core.Data;
    using global::Common.Logging;
    using JetBrains.Annotations;

    /// <summary>
    ///   Delegate to load missing
    /// </summary>
    /// <param name="keys"></param>
    /// <returns></returns>
    public delegate IDictionary<string, object> Loader(ICollection<string> keys);

    /// <summary>
    ///   Cache extensions / helpers.
    /// </summary>
    [PublicAPI]
    public static class CacheExtensions
    {
        private static readonly ILog s_log = LogManager.GetLogger(typeof(CacheExtensions));


        /// <summary>
        ///   Get item from cache or load from external source.
        /// </summary>
        /// <typeparam name="T">Expected type.</typeparam>
        /// <param name="cache"></param>
        /// <param name="key">The key.</param>
        /// <param name="retrieve">The retrieve callback.</param>
        /// <param name="ttl">Expiration timeout.</param>
        /// <param name="shouldCache">Callback check if result should be cached.</param>
        /// <returns>Item.</returns>
        /// <exception cref="System.ArgumentNullException">
        ///   If <paramref name="retrieve" /> callback is null.
        /// </exception>
        public static T GetOrLoad<T>(this ICache cache, string key, [NotNull] Func<T> retrieve, TimeSpan ttl,
            Func<T, bool> shouldCache = null)
            where T : class
        {
            if (retrieve == null)
            {
                throw new ArgumentNullException("retrieve");
            }
            var item = cache.Get<T>(key);
            if (item != null) return item;

            s_log.DebugFormat("'{0}' not found in cache, retrieving...", key);
            item = retrieve();
            s_log.DebugFormat("'{0}' loaded from external source", key);
            if (item != null)
            {
                if (shouldCache == null)
                {
                    cache.Put(key, item, ttl);
                    return item;
                }

                // check if result should be cached
                if (shouldCache(item))
                {
                    cache.Put(key, item, ttl);
                }
                else
                {
                    s_log.InfoFormat("'{0}' indicated as not cacheable, not storing", key);
                }
            }
            return item;
        }


        /// <summary>
        ///   Get item from cache or load from external source.
        /// </summary>
        /// <typeparam name="T">Expected type.</typeparam>
        /// <param name="cache"></param>
        /// <param name="key">The key.</param>
        /// <param name="retrieve">The retrieve callback.</param>
        /// <param name="ttl">Expiration timeout.</param>
        /// <param name="shouldCache">Callback check if result should be cached.</param>
        /// <returns>Item.</returns>
        /// <exception cref="System.ArgumentNullException">
        ///   If <paramref name="retrieve" /> callback is null.
        /// </exception>
        public static Cached<T> GetOrLoad<T>(
            this ICache cache, string key, [NotNull] Func<Cached<T>> retrieve, TimeSpan ttl,
            Func<Cached<T>, bool> shouldCache = null)
        {
            return cache.GetOrLoad<Cached<T>>(key, retrieve, ttl, shouldCache);
        }


        /// <summary>
        ///   Get item from cache or load from external source.
        /// </summary>
        /// <param name="cache">The cache.</param>
        /// <param name="keys">The keys to load.</param>
        /// <param name="loader">The loader.</param>
        /// <param name="ttl">Cache item TTL (used whan adding new items to cache.</param>
        /// <returns>Key/Item pairs as dictionary.</returns>
        /// <exception cref="System.ArgumentNullException">
        ///   <paramref name="cache" />  or <paramref name="keys" /> or <paramref name="loader" /> is null.
        /// </exception>
        public static IDictionary<string, object> GetOrLoad([NotNull] this ICache cache,
            [NotNull] ICollection<string> keys, [NotNull] Loader loader, TimeSpan ttl)
        {
            if (cache == null) throw new ArgumentNullException(nameof(cache));
            if (keys == null) throw new ArgumentNullException(nameof(keys));
            if (loader == null) throw new ArgumentNullException(nameof(loader));

            var cached = cache.Get(keys);

            var missing = (from k in keys
                where cached.ValueOrDefault(k) == null
                select k).ToArray();

            if (missing.Any())
            {
                var loaded = loader(missing);
                foreach (var kv in loaded)
                {
                    cached[kv.Key] = kv.Value;
                }
                cache.Put(loaded, ttl);
            }

            return cached;
        }


        /// <summary>
        ///   Gets the specified key.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="cache">Cache implementation</param>
        /// <param name="key">The key.</param>
        /// <returns></returns>
        /// <exception cref="CacheException">If cached item cannot be casted to requested type.</exception>
        public static T Get<T>([NotNull] this ICache cache, string key)
            where T : class
        {
            var cached = cache.Get(key);
            if (cached == null)
            {
                return null;
            }

            var obj = cached as T;
            if (obj == null)
            {
                throw new CacheException("Error casting item '{0}' from type {1} to {2}"
                    .ApplyArgs(key, cached.GetType().Name, typeof(T).Name));
            }

            return obj;
        }
    }
}