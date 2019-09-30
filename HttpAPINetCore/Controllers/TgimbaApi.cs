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

        // TODO - add user methods

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
    }
}
