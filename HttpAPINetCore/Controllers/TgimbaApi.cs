using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Shared.interfaces;
using Shared.dto.api;

namespace HttpAPINetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TgimbaApiController : ControllerBase
    {
        private ITgimbaService service = null;
        private IValidationHelper validationHelper = null;

        public TgimbaApiController(ITgimbaService service, IValidationHelper validationHelper) 
        {
            this.service = service;
            this.validationHelper = validationHelper;
        }

        #region User

        [HttpPost("processuserregistration")]
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

        [HttpPost("processuser")]
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
        
        [HttpDelete("delete")]
        public IActionResult DeleteBucketListItem([FromBody] DeleteBucketListItemRequest request)
        {
            try
            {
                this.validationHelper.IsValidRequest(request);

                var userRegistered = this.service.DeleteBucketListItem(request.BucketListItemId,
                                                                        request.Token.EncodedUserName,
                                                                        request.Token.EncodedToken);

                return Ok(userRegistered); // 200
            }
            catch (Exception ex)
            {
                return this.HandleError(ex);
            }
        }
        
        [HttpGet("getbucketlistitems")]
        public IActionResult GetBucketListItem([FromBody] GetBucketListItemRequest request)
        {
            try
            {
                this.validationHelper.IsValidRequest(request);

                var userRegistered = this.service.GetBucketListItems(request.Token.EncodedUserName,
                                                                        request.EncodedSortString,                                                                  
                                                                        request.Token.EncodedToken,
                                                                        request.EncodedSearchString);

                return Ok(userRegistered); // 200
            }
            catch (Exception ex)
            {
                return this.HandleError(ex);
            }
        }

        [HttpPost("upsert")]
        public IActionResult UpsertBucketListItem([FromBody] UpsertBucketListItemRequest request)
        {
            try
            {
                this.validationHelper.IsValidRequest(request);

                var userRegistered = this.service.UpsertBucketListItem(request.BucketListItem,
                                                                        request.Token.EncodedUserName,
                                                                        request.Token.EncodedToken);

                return Ok(userRegistered); // 200
            }
            catch (Exception ex)
            {
                return this.HandleError(ex);
            }
        }
        #endregion

        #region Misc

        [HttpGet("getsystemstatistics")]
        public IActionResult GetSystemStatistics()
        {
            try
            {
                var systemStatistics = this.service.GetSystemStatistics();

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

        [HttpGet("getsystembuildstatistics")]
        public IActionResult GetSystemBuildStatistics()
        {
            try
            {
                var systemBuildStatistics = this.service.GetSystemBuildStatistics();

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

        [HttpPost("log")]
        public IActionResult Log([FromBody] string msg)
        {
            try 
            {
                if (string.IsNullOrEmpty(msg))
                {
                    return BadRequest();
                }

                this.service.Log(msg);
                return Ok(); // 200
            } 
            catch(Exception ex)
            {
                return StatusCode(Convert.ToInt32(HttpStatusCode.InternalServerError));
            }
        }
        
        [HttpGet("test")]
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

        [HttpPost("logindemouser")]
        public IActionResult LoginDemoUser()
        {
            try
            {
                var token = this.service.LoginDemoUser();

                return Ok(token); // 200
            }
            catch (Exception ex)
            {
                this.service.Log(ex.Message);
                return StatusCode(Convert.ToInt32(HttpStatusCode.InternalServerError));
            }
        }

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
