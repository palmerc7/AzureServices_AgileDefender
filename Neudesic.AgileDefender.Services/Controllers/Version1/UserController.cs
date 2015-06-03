using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

using Neudesic.AgileDefender.Services.DataObjects;

namespace Neudesic.AgileDefender.Services.Controllers
{
    [RoutePrefix("api/v1/user")]
    public class UserController : ApiController
    {
        public UserController()
        {
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
            if (string.IsNullOrEmpty(emailAddress))
                return NotFound();

            var user = new User();
            try
            {
                // Just returning fake data for now
                user = new User
                {
                    Name = "Chris Palmer",
                    Email = "chris.palmer@neudesic.com"
                };
            }
            catch
            {
            }

            user.IsSuccess = true;

            return Ok(user);
        }
    }
}
