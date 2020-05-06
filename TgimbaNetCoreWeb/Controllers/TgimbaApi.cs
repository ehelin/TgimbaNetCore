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
            var EncodedUserName = this.Request.Headers["EncodedUserName"];
            var EncodedToken = this.Request.Headers["EncodedToken"];

            return this.sharedTgimbaApiController.DeleteBucketListItem(EncodedUserName, EncodedToken, BucketListItemId);
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
        public IActionResult GetSystemStatistics(string encodedUser, string encodedToken)
        {
            return this.sharedTgimbaApiController.GetSystemStatistics(encodedUser, encodedToken);
        }

        [HttpGet("getsystembuildstatistics")]
        public IActionResult GetSystemBuildStatistics(string encodedUser, string encodedToken)
        {
            return this.sharedTgimbaApiController.GetSystemBuildStatistics(encodedUser, encodedToken);
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
