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

namespace Alphacloud.Common.Core.Data
{
    /// <summary>
    /// Various numbers extensions.
    /// </summary>
    public static class NumberExtensions
    {
        /// <summary>
        ///   Determine whether number is in specified range (inclusive).
        /// </summary>
        /// <param name="number">The number.</param>
        /// <param name="min">The min value.</param>
        /// <param name="max">The max value.</param>
        /// <returns></returns>
        public static bool InRange(this double number, double min, double max)
        {
            return number >= min && number <= max;
        }
    }
}
