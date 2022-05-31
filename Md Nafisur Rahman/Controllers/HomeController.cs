namespace Md_Nafisur_Rahman.Controllers
{
    public class HomeController : ApiController
    {

        public static string longSentence = "";


        [HttpGet]
        public string Get(HttpActionContext actionContext)
        {
            
            var token = actionContext.Request.Headers.page-size;
            var id = Convert.ToInt32(headerValues.FirstOrDefault());
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
            return Request.CreateResponse(HttpStatusCode.OK, "sentence sent");
        }

    }
}
