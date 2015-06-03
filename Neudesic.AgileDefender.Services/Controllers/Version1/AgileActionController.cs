using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Neudesic.AgileDefender.Services.Controllers
{
    [RoutePrefix("api/v1/agileaction")]
    public class AgileActionController : ApiController
    {
        public AgileActionController()
        {
        }

        [Route("validate")]
        public HttpResponseMessage Get()
        {
            return new HttpResponseMessage()
            {
                Content = new StringContent(string.Format("Validate SUCCESS from AgileAction API: {0}", DateTime.Now.ToString()))
            };
        }
    }
}
