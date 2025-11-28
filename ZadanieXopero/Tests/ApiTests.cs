using RestSharp;
using System.Text.Json;
using ZadanieXopero.DTO;

namespace ZadanieXopero.Tests
{
    [TestFixture]
    public class ApiTests
    {
        private const string BASE_URL = "https://reqres.in/";
        string projectLocation = Directory.GetCurrentDirectory().Substring(0, Directory.GetCurrentDirectory().IndexOf("ZadanieXopero"));
        protected string testDataPath = "\\ZadanieXopero\\TestData\\";

        [Test]
        public void GetUserMethodTest() {

            RestClient client = new RestClient(BASE_URL);

            RestRequest getRequest = new RestRequest("api/users/{id}", Method.Get);
            getRequest.AddUrlSegment("id", 2);
            getRequest.AddHeader("Accept", "application/json");
            getRequest.AddHeader("x-api-key", "reqres-free-v1");

            RestResponse response = client.Execute(getRequest);
            GetUser user = JsonSerializer.Deserialize<GetUser>(response.Content);

            Assert.That(response.StatusCode.ToString, Is.EqualTo("OK"));
            Assert.That(user.data.email, Is.EqualTo("janet.weaver@reqres.in"));
            Assert.That(user.data.firstName, Is.EqualTo("Janet"));
        }

        [Test]
        public void PutUserMethodTest()
        {
            RestClient client = new RestClient(BASE_URL);

            RestRequest putRequest = new RestRequest("api/users/{id}", Method.Put);
            putRequest.AddUrlSegment("id", 2);
            putRequest.AddHeader("Accept", "application/json");
            putRequest.AddHeader("Content-Type", "application/json");
            putRequest.AddHeader("x-api-key", "reqres-free-v1");

            StreamReader reader = new(projectLocation + testDataPath + "PutUser" + ".json");
            putRequest.AddJsonBody(reader.ReadToEnd());
            
            RestResponse response = client.Execute(putRequest);
            PutUserData user = JsonSerializer.Deserialize<PutUserData>(response.Content);

            Assert.That(response.StatusCode.ToString, Is.EqualTo("OK"));
            Assert.That(user.username, Is.EqualTo("JohnDoe"));
            Assert.That(user.email, Is.EqualTo("john.doe@example.com"));
            Assert.That(user.password, Is.EqualTo("password"));
        }

        [Test]
        public void DeleteUserMethodTest()
        {
            RestClient client = new RestClient(BASE_URL);
            RestRequest deleteRequest = new RestRequest("api/users/{id}", Method.Delete);
            deleteRequest.AddUrlSegment("id", 5);
            deleteRequest.AddHeader("Accept", "application/json");
            deleteRequest.AddHeader("x-api-key", "reqres-free-v1");

            RestResponse response = client.Execute(deleteRequest);
            Assert.That(response.StatusCode.ToString, Is.EqualTo("NoContent"));
        }
    }
}
