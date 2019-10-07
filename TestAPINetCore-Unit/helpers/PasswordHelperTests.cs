using BLLNetCore.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.interfaces;
using System;

namespace TestAPINetCore_Unit.helpers
{
    [TestClass]
    public class PasswordHelperTests : BaseTest
    {
        private IPassword sut = null;

        public PasswordHelperTests() {
            sut = new PasswordHelper();
        }

        [TestMethod]
        public void PasswordsMatch_HappyPathTest()
        {
            throw new NotImplementedException();
            // TODO - passwords match
            // TODO - test HashwordPassword(args) is called
        }
        // TODO - alternate test - passwords do not match

        [TestMethod]
        public void GetSalt_HappyPathTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void HashPassword_HappyPathTest()
        {
            throw new NotImplementedException();
        }
    }
}
