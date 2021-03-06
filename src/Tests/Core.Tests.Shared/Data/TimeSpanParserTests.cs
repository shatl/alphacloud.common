﻿#region copyright

// Copyright 2013-2016 Alphacloud.Net
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

// ReSharper disable ExceptionNotDocumented
// ReSharper disable HeapView.ClosureAllocation
// ReSharper disable ExceptionNotDocumentedOptional
// ReSharper disable HeapView.DelegateAllocation
// ReSharper disable HeapView.ObjectAllocation
// ReSharper disable HeapView.ObjectAllocation.Evident
// ReSharper disable HeapView.BoxingAllocation
namespace Core.Tests.Data
{
    using System;
    using System.Globalization;
    using Alphacloud.Common.Core.Data;
    using FluentAssertions;
    using NUnit.Framework;


    [TestFixture]
    class TimeSpanParserTests
    {
        [Test]
        public void Should_Parse_HHMM()
        {
            var result = TimeSpan.ParseExact("13:59", "g", CultureInfo.InvariantCulture);

            TimeSpan ts;

            TimeSpanParser.TryParseTime("13:59", out ts).Should().BeTrue();
            ts.Should().Be(result);

            TimeSpanParser.TryParseTime("1359", out ts).Should().BeTrue();
            ts.Should().Be(result);

            TimeSpanParser.TryParseTime("1", out ts).Should().BeTrue();
            ts.Should().Be(1.Hours());
        }

        #region Setup/Teardown

        [SetUp]
        public void SetUp()
        {
        }


        [TearDown]
        public void TearDown()
        {
        }

        #endregion
    }

}