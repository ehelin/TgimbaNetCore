using BLLNetCore.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.interfaces;
using Shared.dto;
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
        [Ignore]
        public void PasswordsMatch_HappyPathTest()
        {
            throw new NotImplementedException();
            // TODO - passwords match
            // TODO - test HashwordPassword(args) is called
        }
        // TODO - alternate test - passwords do not match

        [TestMethod]
        [Ignore]
        public void GetSalt_HappyPathTest()
        {
            throw new NotImplementedException();
        }

        [TestMethod]
        public void HashPassword_HappyPathTest()
        {
            var password = "IAmAPassword";
            var salt = "IAmAComplicatedSaltThatIsAtLeastEightBytesLong";
            var passwordDto = new Password(password, salt);
            var updatedPasswordDto = sut.HashPassword(passwordDto);
            Assert.IsNotNull(updatedPasswordDto.SaltedHashedPassword);
            Assert.IsTrue(updatedPasswordDto.SaltedHashedPassword.Length>0);
        }
    }
}
