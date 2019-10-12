using System;
using BLLNetCore.Security;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shared.dto;
using Shared.interfaces;

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
        public void PasswordsMatch_True()
        {
            var existingUserPassword = "IAmAnExistingUserPassword";
            var existingUserSalt = "IAmAnExistingUserSalt";
            var existingPasswordDto = new Password(existingUserPassword, existingUserSalt);
            var hashedExistingUserSaltedPassword = sut.HashPassword(existingPasswordDto);

            var loginPassword = "IAmAnExistingUserPassword";
            var loginPasswordDto = new Password(loginPassword, existingUserSalt);
            var hashedLoginUserSaltedPassword = sut.HashPassword(loginPasswordDto);

            var user = new User();
            user.Password = hashedExistingUserSaltedPassword.SaltedHashedPassword;
            user.Salt = existingUserSalt;

            var passwordsMatch = sut.PasswordsMatch(hashedLoginUserSaltedPassword, user);

            Assert.IsTrue(passwordsMatch);
        }

        [TestMethod]
        public void PasswordsMatch_False()
        {
            var existingUserPassword = "IAmAnExistingUserPassword";
            var existingUserSalt = "IAmAnExistingUserSalt";
            var existingPasswordDto = new Password(existingUserPassword, existingUserSalt);
            var hashedExistingUserSaltedPassword = sut.HashPassword(existingPasswordDto);

            var loginPassword = "IAmAnExistingUserPasswordThatIsDifferent";
            var loginPasswordDto = new Password(loginPassword, existingUserSalt);
            var hashedLoginUserSaltedPassword = sut.HashPassword(loginPasswordDto);

            var user = new User();
            user.Password = hashedExistingUserSaltedPassword.SaltedHashedPassword;
            user.Salt = existingUserSalt;

            var passwordsMatch = sut.PasswordsMatch(hashedLoginUserSaltedPassword, user);

            Assert.IsFalse(passwordsMatch);
        }

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
