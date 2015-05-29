using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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

    }
}
