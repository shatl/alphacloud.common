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

namespace Alphacloud.Common.Infrastructure.Transformations
{
    /// <summary>
    ///   Provides services for converting values from one to another.
    /// </summary>
    public interface IEncoder<T>
    {
        /// <summary>
        ///   Converts specified source value.
        /// </summary>
        /// <param name="source">The value.</param>
        /// <returns>Converted value.</returns>
        T Encode(T source);
    }

    /// <summary>
    ///   Two-way converstion service.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface ITransformer<T> : IEncoder<T>
    {
        /// <summary>
        ///   Decode value.
        ///   This operation is reverse to <see cref="IEncoder{T}.Encode" />
        /// </summary>
        /// <param name="encoded">Encoded value.</param>
        /// <returns>Decoded value.</returns>
        T Decode(T encoded);
    }
}