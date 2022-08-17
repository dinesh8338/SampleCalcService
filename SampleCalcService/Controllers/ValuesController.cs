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
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public HttpResponseMessage Post([FromBody] XElement value)
        {
            try
            {
                var calcprocess = new CalculatorOps().CalcProcess(value);
                return new HttpResponseMessage() { Content = new StringContent(calcprocess, Encoding.UTF8, "application/xml") };
                //return calcprocess;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        // PUT api/values/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
