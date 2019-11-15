using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shared.dto;
using Shared.misc;
using System.Collections.Generic;

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
            var encodedUser = "base64=>username";
            var encodedToken = "base64=>token";            
            var decodedUser = "username";
            var decodedToken = "token";
            var bucketListItemToReturn = GetBucketListItemObject();
            var userToReturn = GetUser(decodedUser, decodedToken);

            UpsertBucketListItem_HappyPathTest_SetUps(encodedUser, encodedToken, 
                                                    decodedUser, decodedToken,
                                                    userToReturn, bucketListItemToReturn, 
                                                    returnValidToken);

            var response = this.service.UpsertBucketListItem(bucketListItemToReturn, encodedUser, encodedToken);
            Assert.IsTrue(returnValidToken ? response == true : response == false);

            UpsertBucketListItem_HappyPathTest_Asserts(encodedUser, encodedToken,
                                                        decodedUser, decodedToken, userToReturn,
                                                        bucketListItemToReturn,
                                                        returnValidToken);
        }
        
        private void UpsertBucketListItem_HappyPathTest_SetUps
        (
            string encodedUser,
            string encodedToken,
            string decodedUser,
            string decodedToken,
            User userToReturn,
            BucketListItem bucketListItemToReturn,
            bool returnValidToken
        ) {
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
        }

        private void UpsertBucketListItem_HappyPathTest_Asserts
        (
            string encodedUser,
            string encodedToken,
            string decodedUserNameToReturn,
            string decodedTokenToReturn,
            User userToReturn,
            BucketListItem bucketListItem, 
            bool expectingValidTokenResponse
        ) {           
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
                this.mockBucketListData.Verify(x => x.UpsertBucketListItem
                              (It.Is<BucketListItem>(s => s.Name == bucketListItem.Name),
                                It.Is<string>(s => s == decodedUserNameToReturn))
                                                  , Times.Once);
            } 
            else
            {
                this.mockBucketListData.Verify(x => x.UpsertBucketListItem
                              (It.Is<BucketListItem>(s => s.Name == bucketListItem.Name),
                                It.Is<string>(s => s == decodedUserNameToReturn))
                                                  , Times.Never);
            }
        }

        #endregion

        #region GetBucketListItems(args)

        // TODO - Tests to add
        // happy path (existing records sorted asc by list name)
        // sort asc/desc
        // sort for each column in enum
        // couple of search tests
        // one test with multiple bucket list items
        [TestMethod]
        public void GetBucketListItems_HappyPathTest()
        {
            var encodedUser = "base64=>username";
            var encodedSortString = "base64=>order by ListItemName Desc";
            var encodedToken = "base64=>token";
            var encodedSrchString = "base64=>srchString";
            var decodedUserToReturn = "username";
            var decodedSortStringToReturn = "order by ListItemName Desc";
            var decodedTokenToReturn = "token";
            var decodedSrchStringToReturn = "srchString";
            var userToReturn = GetUser(decodedUserToReturn, decodedTokenToReturn);
            var bucketListItemToReturn = GetBucketListItemObject();
            var bucketListItems = new List<BucketListItem>();
            bucketListItems.Add(bucketListItemToReturn);

            GetBucketListItems_HappyPathTest_SetUps(encodedUser, encodedSortString, encodedToken, encodedSrchString,
                                                    decodedUserToReturn, decodedSortStringToReturn, 
                                                    decodedTokenToReturn, decodedSrchStringToReturn,
                                                    userToReturn, bucketListItems);

            var response = this.service.GetBucketListItems(encodedUser, encodedSortString, encodedToken, encodedSrchString);
            Assert.IsNotNull(response);
            Assert.AreEqual("Bucket list item", response[0].Name);
            
            GetBucketListItems_HappyPathTest_Asserts(encodedUser, encodedSortString, encodedToken, 
                                                     encodedSrchString, decodedUserToReturn,
                                                     decodedTokenToReturn, decodedSortStringToReturn,
                                                     decodedSrchStringToReturn, userToReturn);
        }

        private void GetBucketListItems_HappyPathTest_SetUps
        (
            string encodedUser,
            string encodedSortString,
            string encodedToken,
            string encodedSrchString,
            string decodedUserToReturn,
            string decodedSortStringToReturn,
            string decodedTokenToReturn,
            string decodedSrchStringToReturn,
            User userToReturn,
            IList<BucketListItem> bucketListItemsToReturn
        ) {
            this.mockString.Setup(x => x.DecodeBase64String
                        (It.Is<string>(s => s == encodedUser)))
                            .Returns(decodedUserToReturn);
            this.mockString.Setup(x => x.DecodeBase64String
                        (It.Is<string>(s => s == encodedSortString)))
                            .Returns(decodedSortStringToReturn);
            this.mockString.Setup(x => x.DecodeBase64String
                        (It.Is<string>(s => s == encodedToken)))
                            .Returns(decodedTokenToReturn);
            this.mockString.Setup(x => x.DecodeBase64String
                        (It.Is<string>(s => s == encodedSrchString)))
                            .Returns(decodedSrchStringToReturn);

            this.mockBucketListData.Setup(x => x.GetUser
                        (It.Is<string>(s => s == decodedUserToReturn)))
                            .Returns(userToReturn);
            this.mockBucketListData.Setup(x => x.GetBucketList
                        (It.Is<string>(s => s == decodedUserToReturn),
                        It.Is<Enums.SortColumns>(s => s == Enums.SortColumns.ListItemName),
                        It.Is<bool>(s => s == false),
                        It.Is<string>(s => s == decodedSrchStringToReturn)))
                            .Returns(bucketListItemsToReturn);

            this.mockPassword.Setup(x => x.IsValidToken
                        (It.Is<User>(s => s.Email == userToReturn.Email),
                                            It.Is<string>(s => s == decodedTokenToReturn)))
                                                 .Returns(true);

            this.mockString.Setup(x => x.GetSortColumn
                        (It.Is<string>(s => s == decodedSortStringToReturn)))
                            .Returns(Enums.SortColumns.ListItemName);
            this.mockString.Setup(x => x.HasSortOrderAsc
                        (It.Is<string>(s => s == decodedSortStringToReturn)))
                            .Returns(false);
        }

        private void GetBucketListItems_HappyPathTest_Asserts
        (
            string encodedUser,
            string encodedSortString,
            string encodedToken,
            string encodedSrchString,
            string decodedUserNameToReturn,
            string decodedTokenToReturn,
            string decodedSortStringToReturn,
            string decodedSrchStringToReturn,
            User userToReturn
        ) {
            this.mockString.Verify(x => x.DecodeBase64String
                        (It.Is<string>(s => s == encodedUser))
                            , Times.Once);
            this.mockString.Verify(x => x.DecodeBase64String
                        (It.Is<string>(s => s == encodedSortString))
                            , Times.Once);
            this.mockString.Verify(x => x.DecodeBase64String
                (It.Is<string>(s => s == encodedToken))
                    , Times.Once);
            this.mockString.Verify(x => x.DecodeBase64String
                        (It.Is<string>(s => s == encodedSrchString))
                            , Times.Once);

            this.mockBucketListData.Verify(x => x.GetUser
                       (It.Is<string>(s => s == decodedUserNameToReturn))
                           , Times.Once);
            this.mockBucketListData.Verify(x => x.GetBucketList
                        (It.Is<string>(s => s == decodedUserNameToReturn),
                        It.Is<Enums.SortColumns>(s => s == Enums.SortColumns.ListItemName),
                        It.Is<bool>(s => s == false),
                        It.Is<string>(s => s == decodedSrchStringToReturn))
                            , Times.Once);

            this.mockPassword.Verify(x => x.IsValidToken
                        (It.Is<User>(s => s.Email == userToReturn.Email),
                                            It.Is<string>(s => s == decodedTokenToReturn))
                                            , Times.Once);

            this.mockString.Verify(x => x.GetSortColumn
                        (It.Is<string>(s => s == decodedSortStringToReturn))
                                            , Times.Once);
            this.mockString.Verify(x => x.HasSortOrderAsc
                        (It.Is<string>(s => s == decodedSortStringToReturn))
                                            , Times.Once);
        }

        #endregion

        #region Private

        // TODO - move to base class? consolidate w/other methods?
        private User GetUser(string decodedUser, string decodedToken)
        {
            var salt = "IAmAReallyLongSaltValueToComplicateAPassword";
            var hashedUserPassword = "0W32zG7AdYwR1e3pgZbupRZjvuXOmNhOJcY/B8rm77L23knzTsDD4EeZS6ll5UjbMJUzTmrLNEJmnC07/jCthA2XVBBre1C3LYEo2dhi0s2f4CAWYMW9YT9tC8rcfpyp5FWSH2DAe/kdD3h/qXrrA8utTRD54au09a1heocVCdrZJdwkDXHMnGtLj40nRs8dnGRpKB1Xe9fuDmWLfWSdjRiSr/lWG+v1fMk+LYq51GF44RYL6QofcebRVolAetAkOabFGvLzaUuo5p77RXehNRHUWbT01pFZWrzEYAksNCBFqaXsbUxK488J+/o9MF3XySKBAPoHz/tG6w==";
            var userToReturn = GetUser(1, decodedUser, hashedUserPassword, salt);
            userToReturn.Token = decodedToken;

            return userToReturn;
        }

        #endregion
    }
}
