using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Neudesic.AgileDefender.Services.Controllers
{
    [RoutePrefix("api/v1/config")]
    public class ConfigController : ApiController
    {
        public ConfigController()
        {
        }

        [Route("validate")]
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent(string.Format("Validate SUCCESS from Config API: {0}", DateTime.Now.ToString()))
            };
        }

    }

    [RoutePrefix("api/v2/config")]
    public class ConfigControllerV2 : ApiController
    {
        public ConfigControllerV2()
        {
        }

        [Route("validateV2")]
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent(string.Format("Validate SUCCESS from Config V2 API: {0}", DateTime.Now.ToString()))
            };
        }

    }

}
