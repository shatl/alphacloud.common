﻿#region copyright

// Copyright 2013-2015 Alphacloud.Net
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

namespace Alphacloud.Common.Core.Data.Hash
{
    using System;
    using System.Collections.Generic;
    using JetBrains.Annotations;

    /// <summary>
    ///   Non-cryptographic hash function for general hash-based lookup.
    /// </summary>
    /// <remarks>
    ///   Uses the same seed values as libhashkit.
    ///   http://en.wikipedia.org/wiki/MurmurHash
    ///   https://github.com/enyim/EnyimMemcached/blob/master/Enyim.Caching/HashkitMurmur.cs
    ///   http://blog.teamleadnet.com/2012/08/murmurhash3-ultra-fast-hash-algorithm.html
    /// </remarks>
    internal class Murmur3 : ISimpleHasher
    {
        const uint M = 0x5bd1e995;
        const int R = 24;
        const uint Seed = 0xdeadbeef;

        #region ISimpleHasher Members

        /// <summary>
        /// Computes the hash for specified array.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="start">The start position.</param>
        /// <param name="size">The size.</param>
        /// <returns>32bit hash</returns>
        public uint Compute([NotNull] byte[] array, int start, int size)
        {
            if (array == null)
            {
                throw new ArgumentNullException("array");
            }
            if (start < 0 || start > array.Length)
            {
                throw new ArgumentOutOfRangeException("start");
            }
            if (start + size > array.Length)
            {
                throw new ArgumentOutOfRangeException("size");
            }

            return UnsafeHashCore(array, start, size);
        }


        /// <summary>
        /// Computes the hash for specified array.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>32bit hash</returns>
        public uint Compute([NotNull] int[] data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            var length = data.Length;
            var hash = Initialize(length * 4);

            unchecked
            {
                for (var i = 0; i < length; i++)
                {
                    var current = (uint) data[i];
                    current = current * M;
                    current ^= current >> R;
                    current = current * M;
                    hash = hash * M;
                    hash ^= current;
                }
                return Finalize(hash);
            }
        }


        /// <summary>
        ///   Computes the hash for specified data.
        ///   Use this overload to avoid calling.ToArray()
        /// </summary>
        /// <param name="data">The data.</param>
        /// <returns>32bit hash</returns>
        public uint Compute(IList<int> data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }
            var length = data.Count;
            var hash = Initialize(length * 4);

            unchecked
            {
                for (var i = 0; i < length; i++)
                {
                    var current = (uint) data[i];
                    current = current * M;
                    current ^= current >> R;
                    current = current * M;
                    hash = hash * M;
                    hash ^= current;
                }
                return Finalize(hash);
            }
        }

        #endregion

        static uint Initialize(int length)
        {
            unchecked
            {
                var seed = (uint) (Seed * length);
                var hash = (uint) (seed ^ length);
                return hash;
            }
        }


        static uint Finalize(uint hash)
        {
            unchecked
            {
                hash ^= hash >> 13;
                hash *= M;
                hash ^= hash >> 15;

                return hash;
            }
        }


        // taken from Enyim memcached client.
        static unsafe uint UnsafeHashCore(byte[] data, int offset, int length)
        {
            var hash = Initialize(length);
            var count = length >> 2;

            fixed (byte* start = &data[offset])
            {
                var ptrUInt = (uint*) start;

                while (count > 0)
                {
                    var current = *ptrUInt;

                    current = current * M;
                    current ^= current >> R;
                    current = current * M;
                    hash = hash * M;
                    hash ^= current;

                    count--;
                    ptrUInt++;
                }

                switch (length & 3)
                {
                    case 3:
                        // reverse the last 3 bytes and convert it to an uint
                        // so cast the last to into an UInt16 and get the 3rd as a byte
                        // ABC --> CBA; (UInt16)(AB) --> BA
                        //h ^= (uint)(*ptrByte);
                        //h ^= (uint)(ptrByte[1] << 8);
                        hash ^= *(ushort*) ptrUInt;
                        hash ^= (uint) (((byte*) ptrUInt)[2] << 16);
                        hash *= M;
                        break;

                    case 2:
                        hash ^= *(ushort*) ptrUInt;
                        hash *= M;
                        break;

                    case 1:
                        hash ^= *(byte*) ptrUInt;
                        hash *= M;
                        break;
                }
            }

            return Finalize(hash);
        }
    }
}