using System;
using HttpAPINetCore.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shared.dto.api;
using Shared.dto;
using Shared.interfaces;

namespace TestHttpAPINetCore_Unit
{
    [TestClass]
    public class BucketListTests : BaseTest
    {
        #region DeleteBucketListItem

        [TestMethod]
        public void DeleteBucketListItem_HappyPathTest()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var validationHelper = new Mock<IValidationHelper>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);
            var request = new DeleteBucketListItemRequest()
            {
                BucketListItemId = 1,
                Token = SetTokenRequest()
            };

            IActionResult result = tgimbaApi.DeleteBucketListItem(request);
            OkObjectResult requestResult = (OkObjectResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(200, requestResult.StatusCode);
            tgimbaService.Verify(x => x.DeleteBucketListItem(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            tgimbaService.Verify(x => x.Log(It.IsAny<string>()), Times.Never);
        }

        [TestMethod]
        public void DeleteBucketListItem_ErrorTest()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var validationHelper = new Mock<IValidationHelper>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);
            var request = new DeleteBucketListItemRequest()
            {
                BucketListItemId = 1,
                Token = SetTokenRequest()
            };

            validationHelper.Setup(x => x.IsValidRequest
                                        (It.IsAny<DeleteBucketListItemRequest>()))
                                            .Throws(new ArgumentNullException(""));

            IActionResult result = tgimbaApi.DeleteBucketListItem(request);
            BadRequestResult requestResult = (BadRequestResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(400, requestResult.StatusCode);
            tgimbaService.Verify(x => x.DeleteBucketListItem(It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            tgimbaService.Verify(x => x.Log(It.Is<string>(s => s.Contains("400 BadRequest"))), Times.Once);
        }

        #endregion

        #region GetBucketListItem

        [TestMethod]
        public void GetBucketListItem_HappyPathTest()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var validationHelper = new Mock<IValidationHelper>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);
            var request = new GetBucketListItemRequest()
            {
                Token = SetTokenRequest()
            };

            IActionResult result = tgimbaApi.GetBucketListItem(request);
            OkObjectResult requestResult = (OkObjectResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(200, requestResult.StatusCode);
            tgimbaService.Verify(x => x.GetBucketListItems(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            tgimbaService.Verify(x => x.Log(It.IsAny<string>()), Times.Never);
        }

        [TestMethod]
        public void GetBucketListItem_ErrorTest()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var validationHelper = new Mock<IValidationHelper>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);
            var request = new GetBucketListItemRequest()
            {
                Token = SetTokenRequest()
            };

            validationHelper.Setup(x => x.IsValidRequest
                                        (It.IsAny<GetBucketListItemRequest>()))
                                            .Throws(new ArgumentNullException(""));

            IActionResult result = tgimbaApi.GetBucketListItem(request);
            BadRequestResult requestResult = (BadRequestResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(400, requestResult.StatusCode);
            tgimbaService.Verify(x => x.GetBucketListItems(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            tgimbaService.Verify(x => x.Log(It.Is<string>(s => s.Contains("400 BadRequest"))), Times.Once);
        }

        #endregion

        #region GetBucketListItem

        [TestMethod]
        public void UpsertBucketListItem_HappyPathTest()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var validationHelper = new Mock<IValidationHelper>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);
            var request = new UpsertBucketListItemRequest()
            {
                Token = SetTokenRequest()
            };

            IActionResult result = tgimbaApi.UpsertBucketListItem(request);
            OkObjectResult requestResult = (OkObjectResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(200, requestResult.StatusCode);
            tgimbaService.Verify(x => x.UpsertBucketListItem(It.IsAny<BucketListItem>(), It.IsAny<string>(), It.IsAny<string>()), Times.Once);
            tgimbaService.Verify(x => x.Log(It.IsAny<string>()), Times.Never);
        }

        [TestMethod]
        public void UpsertBucketListItem_ErrorTest()
        {
            var tgimbaService = new Mock<ITgimbaService>();
            var validationHelper = new Mock<IValidationHelper>();
            var tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);
            var request = new UpsertBucketListItemRequest()
            {
                Token = SetTokenRequest()
            };

            validationHelper.Setup(x => x.IsValidRequest
                                        (It.IsAny<UpsertBucketListItemRequest>()))
                                            .Throws(new ArgumentNullException(""));

            IActionResult result = tgimbaApi.UpsertBucketListItem(request);
            BadRequestResult requestResult = (BadRequestResult)result;

            Assert.IsNotNull(requestResult);
            Assert.AreEqual(400, requestResult.StatusCode);
            tgimbaService.Verify(x => x.UpsertBucketListItem(It.IsAny<BucketListItem>(), It.IsAny<string>(), It.IsAny<string>()), Times.Never);
            tgimbaService.Verify(x => x.Log(It.Is<string>(s => s.Contains("400 BadRequest"))), Times.Once);
        }

        #endregion
    }
}
