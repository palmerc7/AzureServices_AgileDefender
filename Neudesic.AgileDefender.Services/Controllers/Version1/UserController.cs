using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.ApplicationInsights;
//using Microsoft.WindowsAzure.Mobile.Service.Security;

using Neudesic.AgileDefender.Services.DataObjects;
using Neudesic.AgileDefender.Services.Processors;
using Neudesic.AgileDefender.Services.Helpers;

namespace Neudesic.AgileDefender.Services.Controllers
{
    //[AuthorizeLevel(AuthorizationLevel.Anonymous)]
    [RoutePrefix("api/v1/user")]
    public class UserController : ApiController
    {
        private TelemetryClient telemetryClient;
        private UserProcessor userProcessor;

        public UserController()
        {
            telemetryClient = new TelemetryClient();
            userProcessor = new UserProcessor();
        }

        [HttpGet]
        [Route("validate")]
        public HttpResponseMessage Validate()
        {
            telemetryClient.TrackEvent("User.Validate");
            return new HttpResponseMessage()
            {
                Content = new StringContent(string.Format("Validate SUCCESS from User API: {0}", DateTime.Now.ToString()))
            };
        }

        [HttpGet]
        [Route("getUserByEmail")]
        [ResponseType(typeof(User))]
        public IHttpActionResult GetUserByEmail(string emailAddress)
        {
            telemetryClient.TrackEvent("User.GetUserByEmail");
            var user = new User();
            if (string.IsNullOrEmpty(emailAddress))
            {
                // Changed from HTTP 404 Error, which is sometimes appropriate
                //return NotFound();

                // Sending nice message for client presentation
                user.ErrorMessage = MessageResources.UserNotFound;
            }

            try
            {
                user = userProcessor.GetUserByEmail(emailAddress);
            }
            catch (Exception ex)
            {
                telemetryClient.TrackException(ex);
            }

            user.IsSuccess = true;
            return Ok(user);
        }

    }
}
