using System;
using System.Net;
using HttpAPINetCore.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shared.dto.api;
using Shared.interfaces;

namespace TestHttpAPINetCore_Unit
{
    public class BaseTest
    {
        protected TgimbaApiController tgimbaApi = null;
        protected Mock<ITgimbaService> tgimbaService = null;
        protected Mock<IValidationHelper> validationHelper = null;

        public BaseTest() 
        {
            this.validationHelper = new Mock<IValidationHelper>();
            this.tgimbaService = new Mock<ITgimbaService>();
            this.tgimbaApi = new TgimbaApiController(tgimbaService.Object, validationHelper.Object);
        }

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
    }
}
