using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Neudesic.AgileDefender.Services.Controllers
{
    [RoutePrefix("api/v2/config")]
    public class UserConfigV2Controller : ApiController
    {
        public UserConfigV2Controller()
        {
        }

        [HttpGet]
        [Route("validate")]
        public HttpResponseMessage Validate()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent(string.Format("Validate SUCCESS from UserConfig V2 API: {0}", DateTime.Now.ToString()))
            };
        }
    }
}
