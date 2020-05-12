using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Shared.dto.api;
using Shared.interfaces;

namespace TgimbaNetCoreWebShared.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TgimbaApiController : ControllerBase
    {
        private SharedTgimbaApiController sharedTgimbaApiController = null;

        public TgimbaApiController(ITgimbaService service, IValidationHelper validationHelper)
        {
            this.sharedTgimbaApiController = new SharedTgimbaApiController(service, validationHelper);
        }

        #region User

        [HttpPost("processuserregistration")]
        public IActionResult ProcessUserRegistration([FromBody] RegistrationRequest request)
        {
            return this.sharedTgimbaApiController.ProcessUserRegistration(request);
        }

        [HttpPost("processuser")]
        public IActionResult ProcessUser([FromBody] LoginRequest request)
        {
            return this.sharedTgimbaApiController.ProcessUser(request);
        }

        #endregion

        #region Bucket List Items
        
        [HttpDelete("delete/{BucketListItemId:int}")]
        public IActionResult DeleteBucketListItem(int BucketListItemId)
        {
            IActionResult result = null;
            try 
            {
                var logRequest = new LogMessageRequest();
                logRequest.Message = "Api Starting delete " + BucketListItemId.ToString();
                this.Log(logRequest);

                result = this.sharedTgimbaApiController.DeleteBucketListItem(BucketListItemId);
                //return this.sharedTgimbaApiController.DeleteBucketListItem
                //(
                //    Utilities.GetHeaderValue("EncodedUserName", this.Request),
                //    Utilities.GetHeaderValue("EncodedToken", this.Request), 
                //    BucketListItemId
                // );

                var logRequest2 = new LogMessageRequest();
                logRequest2.Message = "Api Starting leaving";
                this.Log(logRequest2);
            } 
            catch(System.Exception ex)
            {
                var logRequest3 = new LogMessageRequest();
                logRequest3.Message = "Delete Error: " + ex.Message;
                this.Log(logRequest3);
            }

            return result;
        }

        [HttpGet("getbucketlistitems")]
        public IActionResult GetBucketListItem([FromQuery] GetBucketListItemRequest request)
        {
            return this.sharedTgimbaApiController.GetBucketListItem(request);
        }

        [HttpPost("upsert")]
        public IActionResult UpsertBucketListItem([FromBody] UpsertBucketListItemRequest request)
        {
            return this.sharedTgimbaApiController.UpsertBucketListItem(request);
        }

        #endregion

        #region Misc

        [HttpGet("getsystemstatistics")]
        public IActionResult GetSystemStatistics()
        {
            return this.sharedTgimbaApiController.GetSystemStatistics
            (
                Utilities.GetHeaderValue("EncodedUserName", this.Request),
                Utilities.GetHeaderValue("EncodedToken", this.Request)
            );
        }

        [HttpGet("getsystembuildstatistics")]
        public IActionResult GetSystemBuildStatistics(string encodedUser, string encodedToken)
        {
            return this.sharedTgimbaApiController.GetSystemBuildStatistics
            (
                Utilities.GetHeaderValue("EncodedUserName", this.Request),
                Utilities.GetHeaderValue("EncodedToken", this.Request)
            );
        }

        [HttpPost("log")]
        public IActionResult Log([FromBody] LogMessageRequest request)
        {
            return this.sharedTgimbaApiController.Log(request);
        }

        [HttpGet("test")]
        public IActionResult GetTestResult()
        {
            return this.sharedTgimbaApiController.GetTestResult();
        }

        #endregion
    }
}
