using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shared.dto;

namespace TestAPINetCore_Unit
{
    [TestClass]
    public class BucketListTests : BaseTest
    {
        #region UpsertBucketListItem(args)

        // alternative tests
        // -> multiple bucket list items (split(';')
        // -> token wth slash (split(';') -> token = token.Replace("\"", "");
        // -> 

        [TestMethod]
        public void UpsertBucketListItem_HappyPathTest()
        {
            var test = this.GetBucketListItem();

            var encodedBucketListItems = "base64=>bucketListItemsArray";
            var encodedUser = "base64=>username";
            var encodedToken = "base64=>token";            
            var decodedBucketListItems = this.GetBucketListItemSingleString();
            var decodedUser = "username";
            var decodedToken = "token";

            var salt = "IAmAReallyLongSaltValueToComplicateAPassword";
            var hashedUserPassword = "0W32zG7AdYwR1e3pgZbupRZjvuXOmNhOJcY/B8rm77L23knzTsDD4EeZS6ll5UjbMJUzTmrLNEJmnC07/jCthA2XVBBre1C3LYEo2dhi0s2f4CAWYMW9YT9tC8rcfpyp5FWSH2DAe/kdD3h/qXrrA8utTRD54au09a1heocVCdrZJdwkDXHMnGtLj40nRs8dnGRpKB1Xe9fuDmWLfWSdjRiSr/lWG+v1fMk+LYq51GF44RYL6QofcebRVolAetAkOabFGvLzaUuo5p77RXehNRHUWbT01pFZWrzEYAksNCBFqaXsbUxK488J+/o9MF3XySKBAPoHz/tG6w==";
            //var jwtIssuerToReturn = "jwtIssuer";
            //var jwtPrivateKeyToReturn = "jwtPrivateKey";
            var jwtTokenToReturn = "IAmAJwtToken";
            var userToReturn = GetUser(1, decodedUser, hashedUserPassword, salt);
            userToReturn.Token = decodedToken;
            //var hashPasswordDtoToReturn = new Password(decodedPasswordToReturn, userToReturn.Salt);
            //hashPasswordDtoToReturn.SaltedHashedPassword = hashedUserPassword;

            UpsertBucketListItem_HappyPathTest_SetUps(encodedBucketListItems, encodedUser, encodedToken, 
                                                    decodedBucketListItems, decodedUser, decodedToken,
                                                    userToReturn);

            var token = this.service.UpsertBucketListItem(encodedBucketListItems, encodedUser, encodedToken);

            UpsertBucketListItem_HappyPathTest_Asserts(encodedBucketListItems, encodedUser, encodedToken,
                                                        decodedUser, decodedToken, userToReturn);
        }
        
        private void UpsertBucketListItem_HappyPathTest_SetUps
        (
            string encodedBucketListItems,
            string encodedUser,
            string encodedToken,
            string decodedBucketListItems,
            string decodedUser,
            string decodedToken,
            User userToReturn
            //string encodedUserName,
            //string encodedPassword,
            //string decodedUserNameToReturn,
            //string decodedPasswordToReturn,
            //User userToReturn,
            //string jwtPrivateKeyToReturn,
            //string jwtIssuerToReturn,
            //Password hashPasswordDtoToReturn,
            //string jwtTokenToReturn
        )
        {
            this.mockString.Setup(x => x.DecodeBase64String
                         (It.Is<string>(s => s == encodedBucketListItems)))
                             .Returns(decodedBucketListItems);
            this.mockString.Setup(x => x.DecodeBase64String
                        (It.Is<string>(s => s == encodedUser)))
                            .Returns(decodedUser);
            this.mockString.Setup(x => x.DecodeBase64String
                        (It.Is<string>(s => s == encodedToken)))
                            .Returns(decodedToken);

            this.mockBucketListData.Setup(x => x.GetUser
                        (It.Is<string>(s => s == decodedUser)))
                            .Returns(userToReturn);

            this.mockPassword.Setup(x => x.IsValidToken
                        (It.Is<User>(s => s.Email == userToReturn.Email),
                                            It.Is<string>(s => s == decodedToken)))
                                                 .Returns(true);

            //this.mockGenerator.Setup(x => x.GetJwtIssuer()).Returns(jwtIssuerToReturn);
            //this.mockGenerator.Setup(x => x.GetJwtPrivateKey()).Returns(jwtPrivateKeyToReturn);
            //this.mockGenerator.Setup(x => x.GetJwtToken(It.Is<string>(s => s == jwtPrivateKeyToReturn),
            //                                                   It.Is<string>(s => s == jwtIssuerToReturn)))
            //                                                        .Returns(jwtTokenToReturn);
            //this.mockPassword.Setup(x => x.PasswordsMatch
            //            (It.Is<Password>(s => s.GetPassword() == decodedPasswordToReturn
            //                                    && s.Salt == userToReturn.Salt),
            //                                It.Is<User>(s => s.UserName == decodedUserNameToReturn)))
            //                                     .Returns(true);
            //this.mockPassword.Setup(x => x.HashPassword(
            //                            It.Is<Password>(s => s.GetPassword() == decodedPasswordToReturn)))
            //                                .Returns(hashPasswordDtoToReturn);
        }

        private void UpsertBucketListItem_HappyPathTest_Asserts
        (
            string encodedBucketListItems,
            string encodedUser,
            string encodedToken,
            string decodedUserNameToReturn,
            string decodedTokenToReturn,
            User userToReturn
        //string token,
        //string encodedUserName,
        //string encodedPassword,
        //string decodedPasswordToReturn,
        //string jwtPrivateKeyToReturn,
        //string jwtIssuerToReturn,
        //User user
        ) {
            this.mockString.Verify(x => x.DecodeBase64String
                        (It.Is<string>(s => s == encodedBucketListItems))
                            , Times.Once);
            this.mockString.Verify(x => x.DecodeBase64String
                        (It.Is<string>(s => s == encodedUser))
                            , Times.Once); 
            this.mockString.Verify(x => x.DecodeBase64String
                (It.Is<string>(s => s == encodedToken))
                    , Times.Once);

           this.mockBucketListData.Verify(x => x.GetUser
                       (It.Is<string>(s => s == decodedUserNameToReturn))
                           , Times.Once);

            this.mockPassword.Verify(x => x.IsValidToken
                        (It.Is<User>(s => s.Email == userToReturn.Email),
                                            It.Is<string>(s => s == decodedTokenToReturn))
                                            , Times.Once);

            //this.mockPassword.Verify(x => x.PasswordsMatch(It.Is<Password>(s => s.GetPassword() == decodedPasswordToReturn
            //                                                && s.Salt == user.Salt),
            //                                                    It.Is<User>(s => s.UserName == decodedUserNameToReturn)),
            //                                                        Times.Once);

            //this.mockGenerator.Verify(x => x.GetJwtPrivateKey(), Times.Once);
            //this.mockGenerator.Verify(x => x.GetJwtIssuer(), Times.Once);
            //this.mockGenerator.Verify(x => x.GetJwtToken(
            //                            It.Is<string>(s => s == jwtPrivateKeyToReturn),
            //                                It.Is<string>(s => s == jwtIssuerToReturn))
            //                                 , Times.Once);
        }

        #endregion
    }
}
