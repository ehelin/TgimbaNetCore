using System.Collections.Generic;
using Moq;
using TgimbaNetCoreWebShared;
using TgimbaNetCoreWebShared.Models;
using System;
using System.Net;
//using HttpAPINetCore.Controllers;
using TgimbaNetCoreWebShared.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shared.dto.api;
using SharedInterfaces = Shared.interfaces;

namespace TestTgimbaNetCoreWeb
{
    public class BaseTest
    {
        protected Mock<IWebClient> mockWebClient { get; set; }
        protected Mock<ITgimbaHttpClient> mockTgimbaHttpClient { get; set; }

        //protected TgimbaApiController tgimbaApi = null;
        protected Mock<SharedInterfaces.ITgimbaService> tgimbaService = null;
        protected Mock<SharedInterfaces.IValidationHelper> validationHelper = null;

        //public BaseTest()
        //{
        //    this.validationHelper = new Mock<IValidationHelper>();
        //    this.tgimbaService = new Mock<ITgimbaService>();
        //    this.tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);
        //}


        public BaseTest()
        {
            mockWebClient = new Mock<IWebClient>();
            mockTgimbaHttpClient = new Mock<ITgimbaHttpClient>();

            SetupWebClient();
        }

        private void SetupWebClient()
        {
            var bucketListItem = GetBucketListItemModel("base64EncodedGoodUser", "newBucketListItem", "dbId", true);
            var bucketListItems = new List<SharedBucketListModel>();
            bucketListItems.Add(bucketListItem);
            mockWebClient.Setup(x => x.GetBucketListItems(
                                                        "YmFzZTY0RW5jb2RlZEdvb2RVc2Vy",//"base64EncodedGoodUser", 
                                                        "base64EncodedGoodSortString",
                                                        "base64EncodedGoodToken",
                                                        "base64EncodedGoodSrchTerm",
                                                        "base64EncodedGoodSortType",
                                                        "base64EncodedGoodSearchType"
                                                        )).Returns(bucketListItems);

            mockWebClient.Setup(x => x.AddBucketListItem(
                                                        It.IsAny<SharedBucketListModel>(),
                                                        "base64EncodedGoodUser",
                                                        "base64EncodedGoodToken"
                                                        )).Returns(true);

            mockWebClient.Setup(x => x.EditBucketListItem(
                                                        It.Is<SharedBucketListModel>(a => !string.IsNullOrEmpty(a.DatabaseId)),
                                                        "base64EncodedGoodUser",
                                                        "base64EncodedGoodToken"
                                                        )).Returns(true);

            mockWebClient.Setup(x => x.DeleteBucketListItem(
                                                        It.Is<string>(a => !string.IsNullOrEmpty(a)),
                                                        "base64EncodedGoodUser",
                                                        "base64EncodedGoodToken"
                                                        )).Returns(true);

            mockWebClient.Setup(x => x.Login("base64EncodedGoodUser", 
                                                "base64EncodedGoodPass"))
                                                    .Returns("token");

            mockWebClient.Setup(x => x.Registration("base64EncodedGoodUser",
                                                        "base64EncodedGoodEmail",
                                                            "base64EncodedGoodPass"))
                                                                .Returns(true);
        }

        #region From API project

        protected TokenRequest SetTokenRequest(string userName = "userName", string token = "token")
        {
            var login = new TokenRequest()
            {
                EncodedUserName = userName,
                EncodedToken = token
            };

            return login;
        }

        protected LoginRequest SetLoginRequest(string userName = "userName", string password = "password")
        {
            var login = new LoginRequest()
            {
                EncodedUserName = userName,
                EncodedPassword = password
            };

            return login;
        }

        protected UpsertBucketListItemRequest GetUpsertRequest()
        {
            var request = new UpsertBucketListItemRequest()
            {
                Token = SetTokenRequest()
            };

            return request;
        }
        protected LogMessageRequest GetLogMessageRequest()
        {
            var request = new LogMessageRequest()
            {
                Token = SetTokenRequest(),
                Message = "IAmALogMessage"
            };

            return request;
        }
        protected LoginRequest GetLoginRequest()
        {
            var request = new LoginRequest()
            {
                EncodedUserName = "userName",
                EncodedPassword = "password",
            };

            return request;
        }

        protected GetBucketListItemRequest GetBucketListItemRequest()
        {
            var token = SetTokenRequest();

            var request = new GetBucketListItemRequest()
            {
                EncodedUserName = token.EncodedUserName,
                EncodedToken = token.EncodedToken
            };

            return request;
        }

        protected DeleteBucketListItemRequest GetDeleteListItemRequest()
        {
            var token = SetTokenRequest();

            var request = new DeleteBucketListItemRequest()
            {
                EncodedToken = token.EncodedToken,
                EncodedUserName = token.EncodedUserName
            };

            return request;
        }

        protected void BadResultVerify(IActionResult result, int code = 400)
        {
            Assert.IsNotNull(result);

            if (code == 400)
            {
                var badResult = (BadRequestResult)result;
                Assert.AreEqual(code, badResult.StatusCode);
                tgimbaService.Verify(x => x.Log(It.Is<string>(s => s.Contains("400 BadRequest"))), Times.Once);
            }
            else
            {
                Assert.AreEqual(code, Convert.ToInt32(HttpStatusCode.InternalServerError));
                tgimbaService.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
            }
        }

        protected void GoodResultVerify(IActionResult result)
        {
            OkObjectResult requestResult = (OkObjectResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(200, requestResult.StatusCode);
            tgimbaService.Verify(x => x.Log(It.IsAny<string>()), Times.Never);
        }


        #endregion

        #region To Delete

        protected SharedBucketListModel GetBucketListItemModel(string userName, string listItemName = "", string dbIdStr = "", bool extended = false)
        {
            SharedBucketListModel model = new SharedBucketListModel
            {
                Name = listItemName,
                DateCreated = "12/15/2010",
                BucketListItemType = Shared.misc.Enums.BucketListItemTypes.Hot, // TODO - set
                Completed = true,
                Latitude = "123.333",
                Longitude = "555.1345",
                DatabaseId = dbIdStr,
                UserName = userName
            };

            return model;
        }

        protected string GetBucketListItemDbId(string singleLineBucketListItem)
        {
            int pos = singleLineBucketListItem.LastIndexOf(',');
            string dbIdStr = singleLineBucketListItem.Substring(pos + 1, singleLineBucketListItem.Length - (pos + 1));

            return dbIdStr;
        }

        protected string GetBucketListItemSingleString(string userName, string listItemName, string dbIdStr, bool extended = false)
        {
            string[] bucketListItem = GetBucketListItem(userName, listItemName, dbIdStr, extended);
            string singleLineBucketListItem = "";

            foreach (string bucketListItemEntry in bucketListItem)
            {
                singleLineBucketListItem += "," + bucketListItemEntry;
            }

            return singleLineBucketListItem;
        }

        protected string[] GetBucketListItem(string userName, string listItemName = "", string dbIdStr = "", bool extended = false)
        {
            string[] bucketListItems;

            if (extended)
            {
                bucketListItems = new string[8];
            }
            else
            {
                bucketListItems = new string[6];
            }

            bucketListItems[0] = listItemName;
            bucketListItems[1] = "12/15/2010";
            bucketListItems[2] = "Hot";
            bucketListItems[3] = "1";

            if (extended)
            {
                bucketListItems[4] = "123.333";
                bucketListItems[5] = "555.1345";
                bucketListItems[6] = dbIdStr;
                bucketListItems[7] = userName;
            }
            else
            {
                bucketListItems[4] = dbIdStr;
                bucketListItems[5] = userName;
            }

            return bucketListItems;
        }

        #endregion
    }
}

//using System;
//using System.Net;
//using HttpAPINetCore.Controllers;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Shared.dto.api;
//using Shared.interfaces;

//namespace TestHttpAPINetCore_Unit
//{
//    public class BaseTest
//    {
//        protected TgimbaApiController tgimbaApi = null;
//        protected Mock<ITgimbaService> tgimbaService = null;
//        protected Mock<IValidationHelper> validationHelper = null;

//        public BaseTest()
//        {
//            this.validationHelper = new Mock<IValidationHelper>();
//            this.tgimbaService = new Mock<ITgimbaService>();
//            this.tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);
//        }

//        protected TokenRequest SetTokenRequest(string userName = "userName", string token = "token")
//        {
//            var login = new TokenRequest()
//            {
//                EncodedUserName = userName,
//                EncodedToken = token
//            };

//            return login;
//        }

//        protected LoginRequest SetLoginRequest(string userName = "userName", string password = "password")
//        {
//            var login = new LoginRequest()
//            {
//                EncodedUserName = userName,
//                EncodedPassword = password
//            };

//            return login;
//        }

//        protected UpsertBucketListItemRequest GetUpsertRequest()
//        {
//            var request = new UpsertBucketListItemRequest()
//            {
//                Token = SetTokenRequest()
//            };

//            return request;
//        }
//        protected LogMessageRequest GetLogMessageRequest()
//        {
//            var request = new LogMessageRequest()
//            {
//                Token = SetTokenRequest(),
//                Message = "IAmALogMessage"
//            };

//            return request;
//        }
//        protected LoginRequest GetLoginRequest()
//        {
//            var request = new LoginRequest()
//            {
//                EncodedUserName = "userName",
//                EncodedPassword = "password",
//            };

//            return request;
//        }

//        protected GetBucketListItemRequest GetBucketListItemRequest()
//        {
//            var token = SetTokenRequest();

//            var request = new GetBucketListItemRequest()
//            {
//                EncodedUserName = token.EncodedUserName,
//                EncodedToken = token.EncodedToken
//            };

//            return request;
//        }

//        protected DeleteBucketListItemRequest GetDeleteListItemRequest()
//        {
//            var token = SetTokenRequest();

//            var request = new DeleteBucketListItemRequest()
//            {
//                EncodedToken = token.EncodedToken,
//                EncodedUserName = token.EncodedUserName
//            };

//            return request;
//        }

//        protected void BadResultVerify(IActionResult result, int code = 400)
//        {
//            Assert.IsNotNull(result);

//            if (code == 400)
//            {
//                var badResult = (BadRequestResult)result;
//                Assert.AreEqual(code, badResult.StatusCode);
//                tgimbaService.Verify(x => x.Log(It.Is<string>(s => s.Contains("400 BadRequest"))), Times.Once);
//            }
//            else
//            {
//                Assert.AreEqual(code, Convert.ToInt32(HttpStatusCode.InternalServerError));
//                tgimbaService.Verify(x => x.Log(It.IsAny<string>()), Times.Once);
//            }
//        }

//        protected void GoodResultVerify(IActionResult result)
//        {
//            OkObjectResult requestResult = (OkObjectResult)result;

//            Assert.IsNotNull(requestResult);
//            Assert.AreEqual(200, requestResult.StatusCode);
//            tgimbaService.Verify(x => x.Log(It.IsAny<string>()), Times.Never);
//        }
//    }
//}
