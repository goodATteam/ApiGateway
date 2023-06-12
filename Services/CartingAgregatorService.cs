using ApiGateway.Models;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ApiGateway.Services
{
    public class CartingAgregatorService : ICartingAgregatorService
    {
        //static HttpClient httpClient = new HttpClient();

        public Task<string> GetCartingInfo(string cartKey)
        {
            /*using HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, "https://localhost:49155/api/CartingList");

            // получаем ответ
            using HttpResponseMessage response = httpClient.SendAsync(request);

            using HttpContent content = response.Content;*/

            // получаем ответ
            /*using HttpResponseMessage response = httpClient.GetAsync("https://localhost:49155/api/CartingList");
            // получаем ответ
            string content = response.Content.ReadAsStringAsync();*/

            /*var handler = new HttpClientHandler();
            handler.SslProtocols = System.Security.Authentication.SslProtocols.Tls12;
            handler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
            handler.Http2UnencryptedSupport = true;*/

            /*HttpClient httpClient = new HttpClient
            {
                DefaultRequestVersion = HttpVersion.Version20,
                DefaultVersionPolicy = HttpVersionPolicy.RequestVersionOrLower
            };*/

            var socketsHandler = new SocketsHttpHandler
            {
                EnableMultipleHttp2Connections = true
            };
            HttpClient httpClient = new HttpClient(socketsHandler)
            {
                DefaultRequestVersion = HttpVersion.Version20,
                DefaultVersionPolicy = HttpVersionPolicy.RequestVersionExact
            };

            httpClient.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6IlVzZXIxIiwiaHR0cDovL3NjaGVtYXMubWljcm9zb2Z0LmNvbS93cy8yMDA4LzA2L2lkZW50aXR5L2NsYWltcy9yb2xlIjoiQWRtaW4iLCJleHAiOjE2ODY1NzM2MTAsImlzcyI6Imh0dHBzOi8vbG9jYWxob3N0OjQ5MTU5L3N3YWdnZXIvaW5kZXguaHRtbCIsImF1ZCI6Imh0dHBzOi8vbG9jYWxob3N0OjQ5MTU5L3N3YWdnZXIvaW5kZXguaHRtbCJ9.qTOX-5zwaDo4Ijjw2TIOWi52_DzjxNWMFX4FgEux45M");
            var requestUrl = "http://192.168.100.4:49155/api/CartingItem/v1/items?CartKey=" + cartKey;
            return httpClient.GetStringAsync(requestUrl);
        }
    }
}