using System;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Shared.interfaces;

namespace HttpAPINetCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TgimbaApiController : ControllerBase
    {
        private ITgimbaService service = null;

        public TgimbaApiController(ITgimbaService service) 
        {
            this.service = service;
        }

        #region User

        [HttpPost]
        public IActionResult ProcessUserRegistration
        (
            [FromBody]string encodedUser, 
            [FromBody]string encodedEmail, 
            [FromBody]string encodedPass
        ){
            bool isBadRequest = false;

            try
            {
                if (string.IsNullOrEmpty(encodedUser))
                {
                    isBadRequest = true;
                    throw new ArgumentNullException("encodedUser is null or empty");
                }
                else if (string.IsNullOrEmpty(encodedEmail))
                {
                    isBadRequest = true;
                    throw new ArgumentNullException("encodedEmail is null or empty");
                }
                else if (string.IsNullOrEmpty(encodedPass))
                {
                    isBadRequest = true;
                    throw new ArgumentNullException("encodedPass is null or empty");
                }

                var userRegistered = this.service.ProcessUserRegistration(encodedUser, encodedEmail, encodedPass);

                return Ok(userRegistered); // 200
            }
            catch (Exception ex)
            {
                return this.HandleError(isBadRequest, ex);
            }
        }

        [HttpPost]
        public IActionResult ProcessUser([FromBody]string encodedUser, [FromBody]string encodedPass)
        {
            bool isBadRequest = false;

            try
            {
                if (string.IsNullOrEmpty(encodedUser))
                {
                    isBadRequest = true;
                    throw new ArgumentNullException("encodedUser is null or empty");
                }
                else if (string.IsNullOrEmpty(encodedPass))
                {
                    isBadRequest = true;
                    throw new ArgumentNullException("encodedPass is null or empty");
                }

                var token = this.service.ProcessUser(encodedUser, encodedPass);

                return Ok(token); // 200
            }
            catch (Exception ex)
            {
                return this.HandleError(isBadRequest, ex);
            }
        }
        
        #endregion

        #region Bucket List Items

        // TODO - add bucket list item methods

        #endregion

        #region Misc

        [HttpGet]
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

        [HttpGet]
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

        [HttpPost]
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
        
        [HttpGet]
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

        [HttpPost]
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

        private IActionResult HandleError(bool isBadRequest, Exception ex) 
        {
            if (isBadRequest)
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
