using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Microsoft.WindowsAzure.Mobile.Service.Security;

using Neudesic.AgileDefender.Services.DataObjects;
using Neudesic.AgileDefender.Services.Processors;
using Neudesic.AgileDefender.Services.Helpers;

namespace Neudesic.AgileDefender.Services.Controllers
{
    [AuthorizeLevel(AuthorizationLevel.Anonymous)]
    [RoutePrefix("api/v1/user")]
    public class UserController : ApiController
    {
        private UserProcessor userProcessor;

        public UserController()
        {
            userProcessor = new UserProcessor();
        }

        [Route("validate")]
        public HttpResponseMessage Get()
        {
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
            catch
            {
            }

            user.IsSuccess = true;

            return Ok(user);
        }
    }
}
