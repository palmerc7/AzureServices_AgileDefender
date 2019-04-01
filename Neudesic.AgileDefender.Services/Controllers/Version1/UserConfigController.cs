using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
//using Microsoft.WindowsAzure.Mobile.Service.Security;

namespace Neudesic.AgileDefender.Services.Controllers
{
    //[AuthorizeLevel(AuthorizationLevel.Anonymous)]
    [RoutePrefix("api/v1/config")]
    public class UserConfigController : ApiController
    {
        public UserConfigController()
        {
        }

        [HttpGet]
        [Route("validate")]
        public HttpResponseMessage Validate()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent(string.Format("Validate SUCCESS from UserConfig API: {0}", DateTime.Now.ToString()))
            };
        }

    }
}
