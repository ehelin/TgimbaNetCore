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
        #region DeletetBucketListItem(args)

        [DataTestMethod]
        [DataRow(true)]
        [DataRow(false)]
        public void DeletetBucketListItem_HappyPathTest(bool returnValidToken)
        {
            var encodedUser = "base64=>username";
            var encodedToken = "base64=>token";
            var decodedUser = "username";
            var decodedToken = "token";
            var bucketListItemToReturn = GetBucketListItemObject();
            var userToReturn = GetUser(decodedUser, decodedToken);
            var dbBucketListItemId = 3;

            DeletetBucketListItem_HappyPathTest_SetUps(encodedUser, encodedToken,
                                                    decodedUser, decodedToken,
                                                    userToReturn, bucketListItemToReturn,
                                                    returnValidToken);

            var response = this.service.DeleteBucketListItem(dbBucketListItemId, encodedUser, encodedToken);
            Assert.IsTrue(returnValidToken ? response == true : response == false);

            DeletetBucketListItem_HappyPathTest_Asserts(encodedUser, encodedToken,
                                                        decodedUser, decodedToken, userToReturn,
                                                        bucketListItemToReturn,
                                                        returnValidToken, dbBucketListItemId);
        }

        private void DeletetBucketListItem_HappyPathTest_SetUps
        (
            string encodedUser,
            string encodedToken,
            string decodedUser,
            string decodedToken,
            User userToReturn,
            BucketListItem bucketListItemToReturn,
            bool returnValidToken
        )
        {
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

        private void DeletetBucketListItem_HappyPathTest_Asserts
        (
            string encodedUser,
            string encodedToken,
            string decodedUserNameToReturn,
            string decodedTokenToReturn,
            User userToReturn,
            BucketListItem bucketListItem,
            bool expectingValidTokenResponse,
            int dbBucketListItemId
        )
        {
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
                this.mockBucketListData.Verify(x => x.DeleteBucketListItem
                              (It.Is<int>(s => s == dbBucketListItemId))
                                                  , Times.Once);
            }
            else
            {
                this.mockBucketListData.Verify(x => x.DeleteBucketListItem
                              (It.Is<int>(s => s == dbBucketListItemId))
                                                  , Times.Never);
            }
        }

        #endregion

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
                            , Times.AtLeastOnce); 
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

        [DataTestMethod]
        [DataRow(true, null)]                   //valid token/null sort string    
        [DataRow(true, "")]                     //valid token/empty sort string  
        [DataRow(true, "sortString")]           //valid token/sort string    
        [DataRow(false, null)]                  //invalid token/null sort string    
        [DataRow(false, "")]                    //invalid token/empty sort string  
        [DataRow(false, "sortString")]          //invalid token/sort string    
        public void GetBucketListItems_Tests(bool isValidToken, string sortString)
        {
            var encodedUser = "base64=>username";
            var encodedSortString = "base64=>" + sortString;
            var encodedToken = "base64=>token";
            var encodedSrchString = "base64=>srchString";
            var decodedUserToReturn = "username";
            var decodedSortStringToReturn = sortString;
            var decodedTokenToReturn = "token";
            var decodedSrchStringToReturn = "srchString";
            var userToReturn = GetUser(decodedUserToReturn, decodedTokenToReturn);
            var bucketListItemToReturn = GetBucketListItemObject();
            var bucketListItems = new List<BucketListItem>();
            bucketListItems.Add(bucketListItemToReturn);

            GetBucketListItems_HappyPathTest_SetUps(encodedUser, encodedSortString, encodedToken, encodedSrchString,
                                                    decodedUserToReturn, decodedSortStringToReturn, 
                                                    decodedTokenToReturn, decodedSrchStringToReturn,
                                                    userToReturn, bucketListItems, isValidToken);

            var response = this.service.GetBucketListItems(encodedUser, encodedSortString, encodedToken, encodedSrchString);
            if (isValidToken)
            {
                Assert.IsNotNull(response);
                Assert.AreEqual("Bucket list item", response[0].Name);
            } 
            else 
            {
                Assert.IsNull(response);
            }

            GetBucketListItems_HappyPathTest_Asserts(encodedUser, encodedSortString, encodedToken, 
                                                    encodedSrchString, decodedUserToReturn,
                                                    decodedTokenToReturn, decodedSortStringToReturn,
                                                    decodedSrchStringToReturn, userToReturn,
                                                    isValidToken);
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
            IList<BucketListItem> bucketListItemsToReturn,
            bool isValidToken
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
                        (It.Is<string>(s => s == decodedUserToReturn)))
                            .Returns(bucketListItemsToReturn);

            this.mockSearch.Setup(x => x.Search(It.IsAny<List<BucketListItem>>(), 
                                                It.Is<string>(s => s == decodedSrchStringToReturn)))
                                                .Returns(bucketListItemsToReturn);

            this.mockSort.Setup(x => x.Sort
                        (It.IsAny<IList<BucketListItem>>(),
                        It.IsAny<Enums.SortColumns>(),
                        It.IsAny<bool>()))
                            .Returns(bucketListItemsToReturn);

            this.mockPassword.Setup(x => x.IsValidToken
                        (It.Is<User>(s => s.Email == userToReturn.Email),
                                            It.Is<string>(s => s == decodedTokenToReturn)))
                                                 .Returns(isValidToken);

            this.mockString.Setup(x => x.GetSortColumn
                        (It.Is<string>(s => s == decodedSortStringToReturn)))
                            .Returns(Enums.SortColumns.ListItemName);
            this.mockString.Setup(x => x.HasSortOrderAsc
                        (It.Is<string>(s => s == decodedSortStringToReturn)))
                            .Returns(true);
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
            User userToReturn,
            bool isValidToken
        ) {
            this.mockString.Verify(x => x.DecodeBase64String
                        (It.Is<string>(s => s == encodedUser))
                            , Times.AtLeastOnce);
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

            this.mockPassword.Verify(x => x.IsValidToken
                        (It.Is<User>(s => s.Email == userToReturn.Email),
                                            It.Is<string>(s => s == decodedTokenToReturn))
                                            , Times.Once);

            AdditionalAsserts(isValidToken, decodedSortStringToReturn,
                                decodedUserNameToReturn, decodedSrchStringToReturn);
        }

        private void AdditionalAsserts
        (
            bool isValidToken, 
            string decodedSortStringToReturn,
            string decodedUserNameToReturn,
            string decodedSrchStringToReturn
        ) {
            if (isValidToken)
            {
                if (!string.IsNullOrEmpty(decodedSortStringToReturn))
                {
                    SortVerifyOnce(decodedSortStringToReturn);
                }
                else
                {
                    SortVerifyNever(decodedSortStringToReturn);
                }

                SearchVerify(decodedSrchStringToReturn);

                this.mockBucketListData.Verify(x => x.GetBucketList
                        (It.Is<string>(s => s == decodedUserNameToReturn))
                            , Times.Once);
            }
            else
            {
                SortVerifyNever(decodedSortStringToReturn);

                this.mockBucketListData.Verify(x => x.GetBucketList
                            (It.Is<string>(s => s == decodedUserNameToReturn))
                                , Times.Never);
            }
        }

        private void SearchVerify(string decodedSrchStringToReturn)
        {
            if (!string.IsNullOrEmpty(decodedSrchStringToReturn))
            {
                this.mockSearch.Verify(x => x.Search(It.IsAny<IList<BucketListItem>>(),
                                                     It.Is<string>(s => s == decodedSrchStringToReturn))
                                                        , Times.Once);
            } else 
            {
                this.mockSearch.Verify(x => x.Search(It.IsAny<IList<BucketListItem>>(),
                                                     It.Is<string>(s => s == decodedSrchStringToReturn))
                                                        , Times.Never);
            }
        }

        private void SortVerifyOnce(string decodedSortStringToReturn)
        {
            this.mockString.Verify(x => x.GetSortColumn
                        (It.Is<string>(s => s == decodedSortStringToReturn))
                                            , Times.Once);
            this.mockString.Verify(x => x.HasSortOrderAsc
                        (It.Is<string>(s => s == decodedSortStringToReturn))
                                            , Times.Once);
            this.mockSort.Verify(x => x.Sort(It.IsAny<IList<BucketListItem>>(),
                                             It.IsAny<Enums.SortColumns>(),
                                             It.IsAny<bool>())
                                             , Times.Once);
        }

        private void SortVerifyNever(string decodedSortStringToReturn)
        {
            this.mockString.Verify(x => x.GetSortColumn
                        (It.Is<string>(s => s == decodedSortStringToReturn))
                                            , Times.Never);
            this.mockString.Verify(x => x.HasSortOrderAsc
                        (It.Is<string>(s => s == decodedSortStringToReturn))
                                            , Times.Never);
            this.mockSort.Verify(x => x.Sort(It.IsAny<IList<BucketListItem>>(),
                                             It.IsAny<Enums.SortColumns>(),
                                             It.IsAny<bool>())
                                             , Times.Never);
        }

        #endregion

        #region Private Shared

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
