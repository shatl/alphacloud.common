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
namespace Infrastructure.Tests.Instrumentation
{
    using Alphacloud.Common.Infrastructure.Instrumentation;
    using Alphacloud.Common.Testing.Nunit.Attributes;
    using NUnit.Framework;

    [TestFixture]
    public class InstrumentationRuntimeTests
    {

        [Test]
        [SetCulture("ru-RU")]
        [SetUICulture("ru-RU")]
        [SetPrincipal("capture-context")]
        [Ignore("todo")]
        public void Capture_Should_CaptureCurrentContext()
        {
            //var context = InstrumentationRuntime.CaptureContext();
        }
    }
}