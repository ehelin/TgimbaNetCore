using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Shared.dto.api;
using Shared.interfaces;

namespace TgimbaNetCoreWebShared.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SharedTgimbaApiController : ControllerBase
    {
        private ITgimbaService service = null;
        private IValidationHelper validationHelper = null;

        public SharedTgimbaApiController(ITgimbaService service, IValidationHelper validationHelper)
        {
            this.service = service;
            this.validationHelper = validationHelper;
        }

        #region User

        public IActionResult ProcessUserRegistration([FromBody] RegistrationRequest request)
        {
            try
            {
                this.validationHelper.IsValidRequest(request);

                var userRegistered = this.service.ProcessUserRegistration(request.Login.EncodedUserName,
                                                                            request.EncodedEmail,
                                                                            request.Login.EncodedPassword);

                return Ok(userRegistered); // 200
            }
            catch (Exception ex)
            {
                return this.HandleError(ex);
            }
        }

        public IActionResult ProcessUser([FromBody] LoginRequest request)
        {
            try
            {
                this.validationHelper.IsValidRequest(request);

                var token = this.service.ProcessUser(request.EncodedUserName, request.EncodedPassword);

                return Ok(token); // 200
            }
            catch (Exception ex)
            {
                return this.HandleError(ex);
            }
        }

        #endregion

        #region Bucket List Items
        
        //public IActionResult DeleteBucketListItem(string EncodedUserName, string EncodedToken, int BucketListItemId)
        public IActionResult DeleteBucketListItem(int BucketListItemId)
        {
            var logRequest = new LogMessageRequest();
            logRequest.Message = "Service - start eteBucketListItem(arg)";
            this.Log(logRequest);

            try
            {
                //this.validationHelper.IsValidRequest(EncodedUserName, EncodedToken, BucketListItemId);

                //var userRegistered = this.service.DeleteBucketListItem(BucketListItemId,
                //                                                        EncodedUserName,
                //                                                        EncodedToken);

                var userRegistered = this.service.DeleteBucketListItem(BucketListItemId);

                var logRequest2 = new LogMessageRequest();
                logRequest2.Message = "Service - leaving DeleteBucketListItem(arg)";
                this.Log(logRequest2);

                return Ok(userRegistered); // 200
            }
            catch (Exception ex)
            {
                var logRequest3 = new LogMessageRequest();
                logRequest3.Message = "Service - Error - " + ex.Message;
                this.Log(logRequest3);

                return this.HandleError(ex);
            }
        }

        public IActionResult GetBucketListItem([FromQuery] GetBucketListItemRequest request)
        {
            try
            {
                this.validationHelper.IsValidRequest(request);

                var bucketListItems = this.service.GetBucketListItems(request.EncodedUserName,
                                                                        request.EncodedSortString,
                                                                        request.EncodedToken,
                                                                        request.EncodedSearchString,
                                                                        request.EncodedSortType,
                                                                        request.EncodedSearchType);

                return Ok(bucketListItems); // 200
            }
            catch (Exception ex)
            {
                return this.HandleError(ex);
            }
        }

        public IActionResult UpsertBucketListItem([FromBody] UpsertBucketListItemRequest request)
        {
            try
            {
                this.validationHelper.IsValidRequest(request);

                var itemAdded = this.service.UpsertBucketListItem(request.BucketListItem,
                                                                        request.Token.EncodedUserName,
                                                                        request.Token.EncodedToken);

                return Ok(itemAdded); // 200
            }
            catch (Exception ex)
            {
                return this.HandleError(ex);
            }
        }

        #endregion

        #region Misc

        public IActionResult GetSystemStatistics(string encodedUser, string encodedToken)
        {
            try
            {
                var systemStatistics = this.service.GetSystemStatistics(encodedUser, encodedToken);

                if (systemStatistics == null || systemStatistics.Count == 0)
                {
                    return NotFound();
                }

                return Ok(systemStatistics); // 200
            }
            catch (Exception ex)
            {
                this.service.Log(ex.Message);
                return StatusCode(Convert.ToInt32(HttpStatusCode.InternalServerError));
            }
        }

        public IActionResult GetSystemBuildStatistics(string encodedUser, string encodedToken)
        {
            try
            {
                var systemBuildStatistics = this.service.GetSystemBuildStatistics(encodedUser, encodedToken);

                if (systemBuildStatistics == null || systemBuildStatistics.Count == 0)
                {
                    return NotFound();
                }

                return Ok(systemBuildStatistics); // 200
            }
            catch (Exception ex)
            {
                this.service.Log(ex.Message);
                return StatusCode(Convert.ToInt32(HttpStatusCode.InternalServerError));
            }
        }

        public IActionResult Log([FromBody] LogMessageRequest request)
        {
            try
            {
                this.validationHelper.IsValidRequest(request);

                this.service.LogAuthenticated(request.Message, request.Token.EncodedUserName, request.Token.EncodedToken);
                return Ok(); // 200
            }
            catch (Exception ex)
            {
                return StatusCode(Convert.ToInt32(HttpStatusCode.InternalServerError));
            }
        }

        public IActionResult GetTestResult()
        {
            try
            {
                var testResult = this.service.GetTestResult();

                return Ok(testResult); // 200
            }
            catch (Exception ex)
            {
                this.service.Log(ex.Message);
                return StatusCode(Convert.ToInt32(HttpStatusCode.InternalServerError));
            }
        }

        //[HttpPost("logindemouser")]
        //public IActionResult LoginDemoUser()
        //{
        //    try
        //    {
        //        var token = this.service.LoginDemoUser();

        //        return Ok(token); // 200
        //    }
        //    catch (Exception ex)
        //    {
        //        this.service.Log(ex.Message);
        //        return StatusCode(Convert.ToInt32(HttpStatusCode.InternalServerError));
        //    }
        //}

        #endregion

        #region Private methods

        private IActionResult HandleError(Exception ex)
        {
            if (ex is ArgumentNullException)
            {
                this.service.Log("400 BadRequest - " + ex.Message);
                return BadRequest();
            }
            else
            {
                this.service.Log(ex.Message);
                return StatusCode(Convert.ToInt32(HttpStatusCode.InternalServerError));
            }
        }

        #endregion
    }
}
