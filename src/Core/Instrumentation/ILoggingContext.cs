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

namespace Alphacloud.Common.Core.Instrumentation
{
    using System;
    using JetBrains.Annotations;

    /// <summary>
    ///   Diagnostic context
    /// </summary>
    [PublicAPI]
    public interface ILoggingContext
    {
        /// <summary>
        ///   Set new context.
        /// </summary>
        /// <param name="id">Context Id</param>
        /// <returns>Context handle.</returns>
        IDisposable Push(string id);


        /// <summary>
        ///   Pop context.
        /// </summary>
        void Pop();


        /// <summary>
        ///   Clear context.
        /// </summary>
        void Clear();
    }
}