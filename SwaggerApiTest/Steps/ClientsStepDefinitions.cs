using FluentAssertions;
using RestSharp;
using TechTalk.SpecFlow;

namespace SwaggerApiTest.Steps
{
    [Binding]
    public class ClientsStepDefinitions : BaseTest
    {

        [Given(@"Create request '(.*)' with '(.*)' method")]
        public void GivenCreateRequestWithMethod(string endPoint, Method methodName)
        {
            request = new RestRequest(endPoint, methodName);
            request.RequestFormat = DataFormat.Json;
        }

        [Given(@"I create a request body with the content")]
        public void WhenICreateARequestBodyWithTheFollowingValues()
        {
            request.AddJsonBody("{\"swaggerUrl\":\"https://petstore.swagger.io/v2/swagger.json\"}");
            request.OnBeforeDeserialization = resp => { resp.ContentType = "application/json"; };

        }

        [When(@"Execute Api")]
        public void GivenExecuteApi()
        {
            apiResult = api.Execute(request);
        }

        [Then(@"returned status code will be (.*)")]
        public void ThenReturnedStatusCodeWillBe(int expectedStatusCode)
        {
            var code = apiResult.StatusCode;
            code.Should().Be(expectedStatusCode);
        }
    }
}
