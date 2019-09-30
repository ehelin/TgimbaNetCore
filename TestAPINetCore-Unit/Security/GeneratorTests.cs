using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shared.dto;
using Shared;
using BLLNetCore.Security;

namespace TestAPINetCore_Unit
{
    [TestClass]
    public class SecurityTests : BaseTest
    {
        private Generator sut = null;

        public SecurityTests() {
            sut = new Generator();
        }

        [TestMethod]
        public void GetPrivateKey_HappyPathTest()
        {
            var key = sut.GetPrivateKey();
            Assert.IsNotNull(key);
            Assert.IsTrue(key.Length > 0);
        }
    }
}
