using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Neudesic.AgileDefender.Services.Controllers
{
    [RoutePrefix("api/v2/config")]
    public class ConfigV2Controller : ApiController
    {
        public ConfigV2Controller()
        {
        }

        [Route("validate")]
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent(string.Format("Validate SUCCESS from Config V2 API: {0}", DateTime.Now.ToString()))
            };
        }

    }
}
