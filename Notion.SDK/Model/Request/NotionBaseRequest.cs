using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Web;

namespace Notion.SDK.Model.Request
{
    public abstract class NotionBaseRequest<TContent, TResponse>
    {

        // HttpClient is intended to be instantiated once per application, rather than per-use. See Remarks.
        protected static readonly HttpClient client = new HttpClient();

        public NotionBaseRequest(string token)
        {
           
            Token = token;
        }

        protected virtual string ServerUrl => "https://api.notion.com/v1/";
        protected abstract string Uri { get; }

        protected abstract HttpMethod Method { get; }

        protected virtual string ContentType => "application/json";

        public TContent? Content { get; set; }

        private string Token { get; set; }

        public virtual async Task<TResponse?> ExcuteAsync()
        {
            HttpRequestMessage request = new()
            {
                RequestUri = new Uri(new Uri(ServerUrl), Uri),
                Method = Method
            };

            switch (request.Method.ToString())
            {
                case "GET":
                    break;
                default:
                    request.Content = new StringContent(JsonSerializer.Serialize(this.Content), Encoding.UTF8, ContentType);
                    break;
            }
           
            request.Headers.Add("Accept", "*/*");
            request.Headers.Add("Notion-Version", "2021-08-16");
            request.Headers.Add("Authorization", $"Bearer {Token}");

            var response = await client.SendAsync(request);
            if (response != null && response.IsSuccessStatusCode)
            {
                try
                {

                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    var authorize = await JsonSerializer.DeserializeAsync<TResponse>(responseStream);
                    return authorize;
                }
                catch (Exception ex)
                {
                    var content = await response.Content.ReadAsStringAsync();
                    throw new Exception($"response deserialize faild , content: {content}", ex);
                }
            }
            else
            {
                throw new Exception($"Call Api Faild , code : {response?.StatusCode} , msg: {await response?.Content.ReadAsStringAsync()}");
            }
        }
    }
}
