using SampleCalcService.Business;
using SampleCalcService.Entities;
using SampleCalcService.Entities.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Xml.Linq;

namespace SampleCalcService.Controllers
{
    public class ValuesController : ApiController
    {
        // POST api/values
        [HttpPost]
        public HttpResponseMessage Post([FromBody] XElement value)
        {
            var calcprocess = new CalculatorOps().CalcProcess(value);
            if(calcprocess != null)
            {
               return new HttpResponseMessage() { Content = new StringContent(calcprocess, Encoding.UTF8, "application/xml") };
            }
            else
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
        }
    }
}
