using AuthPage.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace AuthPage.Implemenatations
{
    public class FakeBackendHandler : HttpClientHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var users = new[] { new { Id = 1, Username = "test", Password = "test", FirstName = "Test", LastName = "User" } };
            var path = request.RequestUri.AbsolutePath;
            var method = request.Method;
            var saftyCharItems = new List<string>();

            if (path == "/users/authenticate" && method == HttpMethod.Post)
            {
                return await authenticate();
            }
            else if (path == "/users" && method == HttpMethod.Get)
            {
                return await getUsers();
            }
            else if (path == "/chart/GetSaftyChart" && method == HttpMethod.Get)
            {
                
                return await getSaftyChart();
            }
            else
            {
                // pass through any requests not handled above
                return await base.SendAsync(request, cancellationToken);
            }

            // route functions

            async Task<HttpResponseMessage> authenticate()
            {
                var bodyJson = await request.Content.ReadAsStringAsync();
                var body = JsonSerializer.Deserialize<Dictionary<string, string>>(bodyJson);
                var user = users.FirstOrDefault(x => x.Username == body["username"] && x.Password == body["password"]);

                if (user == null)
                    return await error("Username or password is incorrect");

                return await ok(new
                {
                    id = user.Id,
                    username = user.Username,
                    firstName = user.FirstName,
                    lastName = user.LastName,
                    Token = "fake-jwt-token"
                });
            }

            async Task<HttpResponseMessage> getUsers()
            {
                if (!isLoggedIn()) return await unauthorized();
                return await ok(users);
            }

            // helper functions

            async Task<HttpResponseMessage> ok(object body)
            {
                return await jsonResponse(HttpStatusCode.OK, body);
            }

            async Task<HttpResponseMessage> error(string message)
            {
                return await jsonResponse(HttpStatusCode.BadRequest, new { message });
            }

            async Task<HttpResponseMessage> unauthorized()
            {
                return await jsonResponse(HttpStatusCode.Unauthorized, new { message = "Unauthorized" });
            }

            async Task<HttpResponseMessage> jsonResponse(HttpStatusCode statusCode, object content)
            {
                var response = new HttpResponseMessage
                {
                    StatusCode = statusCode,
                    Content = new StringContent(JsonSerializer.Serialize(content), Encoding.UTF8, "application/json")
                };

                await Task.Delay(500);

                return response;
            }

            bool isLoggedIn()
            {
                return request.Headers.Authorization?.Parameter == "fake-jwt-token";
            }

             async Task<HttpResponseMessage> getSaftyChart()
            {
                return await ok(saftyCharItems.AsEnumerable());
            }
        }

        
    }
}
