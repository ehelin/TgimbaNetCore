using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shared;
using Shared.dto;
using Shared.interfaces;
using BLLNetCore.helpers;

namespace TestAPINetCore_Unit
{
    [TestClass]
    public class BucketListTests : BaseTest
    {
        #region UpsertBucketListItem(args)

        [DataTestMethod]
        [DataRow(true)]         
        [DataRow(false)] 
        public void UpsertBucketListItem_HappyPathTest(bool returnValidToken)
        {
            var test = this.GetBucketListItem();
            IConversion conversionHelper = new ConversionHelper();

            var encodedBucketListItems = "base64=>bucketListItemsArray";
            var encodedUser = "base64=>username";
            var encodedToken = "base64=>token";            
            var decodedBucketListItems = this.GetBucketListItemSingleString();
            decodedBucketListItems = decodedBucketListItems.Trim(',');
            var decodedUser = "username";
            var decodedToken = "token";
            var decodedBucketListItemsArray = decodedBucketListItems.Split(',');
            var bucketListItemToReturn = conversionHelper.GetBucketListItem(decodedBucketListItemsArray);

            var salt = "IAmAReallyLongSaltValueToComplicateAPassword";
            var hashedUserPassword = "0W32zG7AdYwR1e3pgZbupRZjvuXOmNhOJcY/B8rm77L23knzTsDD4EeZS6ll5UjbMJUzTmrLNEJmnC07/jCthA2XVBBre1C3LYEo2dhi0s2f4CAWYMW9YT9tC8rcfpyp5FWSH2DAe/kdD3h/qXrrA8utTRD54au09a1heocVCdrZJdwkDXHMnGtLj40nRs8dnGRpKB1Xe9fuDmWLfWSdjRiSr/lWG+v1fMk+LYq51GF44RYL6QofcebRVolAetAkOabFGvLzaUuo5p77RXehNRHUWbT01pFZWrzEYAksNCBFqaXsbUxK488J+/o9MF3XySKBAPoHz/tG6w==";
            var userToReturn = GetUser(1, decodedUser, hashedUserPassword, salt);
            userToReturn.Token = decodedToken;

            UpsertBucketListItem_HappyPathTest_SetUps(encodedBucketListItems, encodedUser, encodedToken, 
                                                    decodedBucketListItems, decodedUser, decodedToken,
                                                    userToReturn, bucketListItemToReturn, decodedBucketListItemsArray,
                                                    returnValidToken);

            var response = this.service.UpsertBucketListItem(encodedBucketListItems, encodedUser, encodedToken);
            Assert.IsTrue(returnValidToken ? response == true : response == false);

            UpsertBucketListItem_HappyPathTest_Asserts(encodedBucketListItems, encodedUser, encodedToken,
                                                        decodedUser, decodedToken, userToReturn,
                                                        decodedBucketListItemsArray, bucketListItemToReturn,
                                                        returnValidToken);
        }
        
        private void UpsertBucketListItem_HappyPathTest_SetUps
        (
            string encodedBucketListItems,
            string encodedUser,
            string encodedToken,
            string decodedBucketListItems,
            string decodedUser,
            string decodedToken,
            User userToReturn,
            BucketListItem bucketListItemToReturn,
            string[] bucketListItemArray,
            bool returnValidToken
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
                                                 .Returns(returnValidToken);

            this.mockConversion.Setup(x => x.GetBucketListItem
                        (It.Is<string[]>(s => s[0] == bucketListItemArray[0])))
                                                 .Returns(bucketListItemToReturn);
        }

        private void UpsertBucketListItem_HappyPathTest_Asserts
        (
            string encodedBucketListItems,
            string encodedUser,
            string encodedToken,
            string decodedUserNameToReturn,
            string decodedTokenToReturn,
            User userToReturn,
            string[] bucketListItemArray,
            BucketListItem bucketListItem, 
            bool expectingValidTokenResponse
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

            if (expectingValidTokenResponse)
            {
                this.mockConversion.Verify(x => x.GetBucketListItem
                            (It.Is<string[]>(s => s[0] == bucketListItemArray[0]))
                                                , Times.Once);

                this.mockBucketListData.Verify(x => x.UpsertBucketListItem
                              (It.Is<BucketListItem>(s => s.Name == bucketListItem.Name),
                                It.Is<string>(s => s == decodedUserNameToReturn))
                                                  , Times.Once);
            } 
            else
            {
                this.mockConversion.Verify(x => x.GetBucketListItem
                            (It.Is<string[]>(s => s[0] == bucketListItemArray[0]))
                                                , Times.Never);

                this.mockBucketListData.Verify(x => x.UpsertBucketListItem
                              (It.Is<BucketListItem>(s => s.Name == bucketListItem.Name),
                                It.Is<string>(s => s == decodedUserNameToReturn))
                                                  , Times.Never);
            }
        }

        #endregion
    }
}
