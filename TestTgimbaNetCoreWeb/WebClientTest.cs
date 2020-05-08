using System.Net.Http;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TgimbaNetCoreWebShared;
using Newtonsoft.Json;
using System.Collections.Generic;
using Shared.dto;

namespace TestTgimbaNetCoreWeb
{
    [TestClass]
    public class WebClientTest : BaseTest
    {
        [TestMethod]
        public void Test_GoodRegistration()
        {
            mockTgimbaHttpClient.Setup(x => x.Post(It.Is<string>(s => s.Contains("/api/tgimbaapi/processuserregistration")),
                                                        It.IsAny<StringContent>()))
                                                                .Returns("true");

            bool goodRegistration = GetWebClient().Registration("base64EncodedGoodUser", 
                                                                    "base64EncodedGoodEmail", 
                                                                        "base64EncodedGoodPass");

            Assert.AreEqual(true, goodRegistration);
            mockTgimbaHttpClient.Verify(x => x.Post(It.Is<string>(s => s.Contains("/api/tgimbaapi/processuserregistration")),
                                                     It.IsAny<StringContent>())
                                                             , Times.Once);
        }

        [TestMethod]
        public void Test_BadRegistration()
        {
            mockTgimbaHttpClient.Setup(x => x.Post(It.Is<string>(s => s.Contains("/api/tgimbaapi/processuserregistration")),
                                                        It.IsAny<StringContent>()))
                                                                .Returns("false");

            bool goodRegistration = GetWebClient().Registration("base64EncodedBadUser", 
                                                                      "base64EncodedBadEmail", 
                                                                           "base64EncodedBadPass");

            Assert.AreEqual(false, goodRegistration);
            mockTgimbaHttpClient.Verify(x => x.Post(It.Is<string>(s => s.Contains("/api/tgimbaapi/processuserregistration")),
                                                     It.IsAny<StringContent>())
                                                             , Times.Once);
        }

        [TestMethod]
        public void Test_GoodLogin()
        {
            mockTgimbaHttpClient.Setup(x => x.Post(It.Is<string>(s => s.Contains("/api/tgimbaapi/processuser")),
                                                      It.IsAny<StringContent>()))
                                                              .Returns("token");

            string token = GetWebClient().Login("base64EncodedGoodUser", "base64EncodedGoodPass");

            Assert.AreEqual("token", token);
            mockTgimbaHttpClient.Verify(x => x.Post(It.Is<string>(s => s.Contains("/api/tgimbaapi/processuser")),
                                                      It.IsAny<StringContent>())
                                                                , Times.Once);
        }

        [TestMethod]
        public void Test_BadLogin()
        {
            mockTgimbaHttpClient.Setup(x => x.Post(It.Is<string>(s => s.Contains("/api/tgimbaapi/processuser")),
                                                      It.IsAny<StringContent>()))
                                                              .Returns("");

            string token = GetWebClient().Login("base64EncodedBadUser", "base64EncodedBadPass");

            Assert.AreEqual("", token);
            mockTgimbaHttpClient.Verify(x => x.Post(It.Is<string>(s => s.Contains("/api/tgimbaapi/processuser")),
                                                      It.IsAny<StringContent>())
                                                                , Times.Once);
        }
        
        [TestMethod]
        public void Test_GoodAddBucketListItem()
        {
            var bucketListItemModel = GetBucketListItemModel("base64EncodedGoodUser", "newBucketListItem", null, true);
            mockTgimbaHttpClient.Setup(x => x.Post(It.Is<string>(s => s.Contains("/api/tgimbaapi/upsert")),
                                                      It.IsAny<StringContent>()))
                                                              .Returns("true");

            var bucketListAdded = GetWebClient().AddBucketListItem(bucketListItemModel, "base64EncodedGoodUser", "base64EncodedGoodToken");

            Assert.IsTrue(bucketListAdded);
            mockTgimbaHttpClient.Verify(x => x.Post(It.Is<string>(s => s.Contains("/api/tgimbaapi/upsert")),
                                                      It.IsAny<StringContent>())
                                                                , Times.Once);
        }

        [TestMethod]
        public void Test_BadAddBucketListItem()
        {
            var bucketListItemModel = GetBucketListItemModel("base64EncodedGoodUser", "newBucketListItem", null, true);
            mockTgimbaHttpClient.Setup(x => x.Post(It.Is<string>(s => s.Contains("/api/tgimbaapi/upsert")),
                                                      It.IsAny<StringContent>()))
                                                              .Returns("false");

            var bucketListAdded = GetWebClient().AddBucketListItem(bucketListItemModel, "base64EncodedGoodUser", "base64EncodedGoodToken");

            Assert.IsFalse(bucketListAdded);
            mockTgimbaHttpClient.Verify(x => x.Post(It.Is<string>(s => s.Contains("/api/tgimbaapi/upsert")),
                                                      It.IsAny<StringContent>())
                                                                , Times.Once);
        }

        [TestMethod]
        public void Test_GoodEditBucketListItem()
        {
            var bucketListItemModel = GetBucketListItemModel("base64EncodedGoodUser", "newBucketListItem", null, true);
            mockTgimbaHttpClient.Setup(x => x.Post(It.Is<string>(s => s.Contains("/api/tgimbaapi/upsert")),
                                                      It.IsAny<StringContent>()))
                                                              .Returns("true");

            var bucketListAdded = GetWebClient().AddBucketListItem(bucketListItemModel, "base64EncodedGoodUser", "base64EncodedGoodToken");

            Assert.IsTrue(bucketListAdded);
            mockTgimbaHttpClient.Verify(x => x.Post(It.Is<string>(s => s.Contains("/api/tgimbaapi/upsert")),
                                                      It.IsAny<StringContent>())
                                                                , Times.Once);
        }

        [TestMethod]
        public void Test_BadEditBucketListItem()
        {
            var bucketListItemModel = GetBucketListItemModel("base64EncodedGoodUser", "newBucketListItem", null, true);
            mockTgimbaHttpClient.Setup(x => x.Post(It.Is<string>(s => s.Contains("/api/tgimbaapi/upsert")),
                                                      It.IsAny<StringContent>()))
                                                              .Returns("false");

            var bucketListAdded = GetWebClient().AddBucketListItem(bucketListItemModel, "base64EncodedGoodUser", "base64EncodedGoodToken");

            Assert.IsFalse(bucketListAdded);
            mockTgimbaHttpClient.Verify(x => x.Post(It.Is<string>(s => s.Contains("/api/tgimbaapi/upsert")),
                                                      It.IsAny<StringContent>())
                                                                , Times.Once);
        }

        [TestMethod]
        public void Test_GoodGetBucketListItems()
        {
            var bucketListItemModel = GetBucketListItemModel("base64EncodedGoodUser", 
                                                                "newBucketListItem", 
                                                                    null, 
                                                                        true);
            var bucketListItem = new BucketListItem()
            {
                Name = "newBucketListItem",
                Created = System.DateTime.Now,
                Category = "Hot",
                Achieved = true,
                Latitude = (decimal)1.1,
                Longitude = (decimal)2.1
            };
            var bucketListItems = new List<BucketListItem>();
            bucketListItems.Add(bucketListItem);
            var bucketListItemsToReturn = JsonConvert.SerializeObject(bucketListItems);

            mockTgimbaHttpClient.Setup(x => x.Get(It.Is<string>(s => s.Contains("/api/tgimbaapi/getbucketlistitems")), 
                It.IsAny<string>(),
                It.IsAny<string>()))
                .Returns(bucketListItemsToReturn);

            var user = Shared.misc.Utilities.EncodeClientBase64String("base64EncodedGoodUser");
            var results = GetWebClient().GetBucketListItems(user,
                                                                    "base64EncodedGoodSortString",
                                                                    "base64EncodedGoodToken",
                                                                    "base64EncodedGoodSrchTerm");

            Assert.IsNotNull(results);
            Assert.AreEqual("newBucketListItem", results[0].Name);
            mockTgimbaHttpClient.Verify(x => x.Get(It.Is<string>(s => s.Contains("/api/tgimbaapi/getbucketlistitems")),
                It.IsAny<string>(),
                It.IsAny<string>())
                , Times.Once);
        }

        [TestMethod]
        public void Test_BadGetBucketListItems()
        {
            mockTgimbaHttpClient.Setup(x => x.Get(It.Is<string>(s => s.Contains("/api/tgimbaapi/getbucketlistitems")),
             It.IsAny<string>(),
             It.IsAny<string>()))
             .Returns("");

            var bucketItemList = GetWebClient().GetBucketListItems("", "", "");

            Assert.IsNull(bucketItemList);
            mockTgimbaHttpClient.Verify(x => x.Get(It.Is<string>(s => s.Contains("/api/tgimbaapi/getbucketlistitems")),
              It.IsAny<string>(),
              It.IsAny<string>())
              , Times.Once);
        }

        private IWebClient GetWebClient()
        {
            IWebClient webClient = new WebClient("https://api.tgimba.com", mockTgimbaHttpClient.Object);

            return webClient;
        }
    }
}
