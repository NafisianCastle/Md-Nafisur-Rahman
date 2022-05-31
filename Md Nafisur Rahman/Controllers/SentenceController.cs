using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Md_Nafisur_Rahman.Controllers
{
    public class SentenceController : ApiController
    {
        public static string longSentence = "";


        [HttpGet]
        public HttpResponseMessage Get()
        {
            Request.Headers.TryGetValues("page-size", out var headerValue);
            var id = Convert.ToInt32(headerValue.SingleOrDefault());
            var sentence = longSentence;
            int max = id;
            var list = new List<string>();
            var word = "";

            for (var i = 0; i < sentence.Length; i++)
            {
                if (sentence[i] == ' ')
                {
                    list.Add(word);
                    word = "";
                }
                else
                {
                    word += sentence[i];
                }
            }
            list.Add(word);

            var answer = "";
            var slice = list[0];
            for (var i = 1; i < list.Count; i++)
            {
                if (slice.Length + list[i].Length + 1 <= max)
                {
                    slice += ' ' + list[i];
                }
                else
                {
                    answer += '\n' + slice;
                    slice = list[i];
                }
            }
            answer += '\n' + slice;
            return Request.CreateResponse(HttpStatusCode.OK, answer);
            //return Ok(answer);
        }

        [HttpPost]
        public HttpResponseMessage Post(string value)
        {
            longSentence = value;
            var HttpClient = new HttpClient();
            HttpClient.DefaultRequestHeaders.Add("page-size", "7");
            return Request.CreateResponse(HttpStatusCode.OK, "sentence sent");
        }
    }
}