using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Lab191.Models.WS;

namespace Lab191.Controllers
{
    public class AccessController : ApiController
    {
        [HttpGet]
        [Route("api/access/helloworld")]
        public Reply HelloWorld()
        {
            Reply oR = new Reply();
            oR.result = 1;
            oR.message = "Mi Hello World en API";

            return oR;
        }
    }

}
