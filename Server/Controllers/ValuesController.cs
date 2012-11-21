using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Server.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            HttpWebRequest request =
                WebRequest.Create(
                    "http://countdown.api.tfl.gov.uk/interfaces/ura/instant_V1?StopCode1=58355&VisitNumber=1&ReturnList=StopCode1,StopPointName,LineName,DestinationText,EstimatedTime,MessageUUID,MessageText,MessagePriority,MessageType,ExpireTime")
                as HttpWebRequest;

            WebResponse response = request.GetResponse();

            Stream responseStream = response.GetResponseStream();

            if ( responseStream != null )
            {
                TextReader reader = new StreamReader(responseStream);
                string responseString = reader.ReadToEnd();

                responseString = responseString.Replace("]", "],");
                responseString = responseString.Remove(responseString.LastIndexOf(","), 1);
                responseString = "[" + responseString + "]";


                return new string[] { responseString };
            }

            return null;
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}