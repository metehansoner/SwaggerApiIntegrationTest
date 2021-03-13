using Newtonsoft.Json;
using RestSharp;
using System.Net.Http;
using System.Text;

namespace SwaggerApiTest.Steps
{
    public abstract class BaseTest
    {
        public static RestClient api { get; set; }

        public static RestRequest request { get; set; }

        public IRestResponse apiResult { get; set; }
        public BaseTest()
        {
            api = new RestClient("https://generator.swagger.io/api/gen");
        }

        public StringContent JsonData<T>(T data)
        {
            var json = JsonConvert.SerializeObject(data);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
        public T ObjectData<T>(string json)
        {
            var result = JsonConvert.DeserializeObject<T>(json);
            return result;
        }
    }
}
