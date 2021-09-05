using Notion.SDK.Model.Objects;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Notion.SDK.Model.Request
{
    public class AuthorizationCodeRequest : NotionBaseRequest<AuthorizationCodeContent, AuthorizeObject>
    {
        public AuthorizationCodeRequest(string code, string redirect_uri) : base("")
        {
            this.Content = new AuthorizationCodeContent(code, redirect_uri);
        }

        protected override string Uri => "oauth/token";

        protected override HttpMethod Method => HttpMethod.Post;

        public override async Task<AuthorizeObject?> ExcuteAsync()
        {
            var requestUri = new Uri(new Uri(ServerUrl), Uri);
            var request = new HttpRequestMessage(this.Method, requestUri)
            {
                Content = new StringContent(JsonSerializer.Serialize(this.Content), Encoding.UTF8, ContentType)

            };
            request.Content.Headers.ContentType = new MediaTypeHeaderValue(ContentType);

            var response = await client.SendAsync(request);
            if (response != null && response.IsSuccessStatusCode)
            {
                try
                {

                    using var responseStream = await response.Content.ReadAsStreamAsync();
                    var authorize = await JsonSerializer.DeserializeAsync<AuthorizeObject>(responseStream);
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
                throw new Exception($"Call Api Faild , code : {response?.StatusCode} , msg: {response?.Content.ReadAsStringAsync().Result}");
            }
        }
    }

    public class AuthorizationCodeContent
    {

        public AuthorizationCodeContent(string code, string uri)
        {
            Code = code;
            RedirectUri = uri;
        }

        /// <summary>
        /// grant_type
        /// 
        /// Always use "authorization_code"
        /// </summary>
        [JsonPropertyName("grant_type")]
        public string GrantType => "authorization_code";

        /// <summary>
        /// code
        /// 
        /// The temporary authorization code received in the incoming request to the
        /// </summary>
        /// <value></value>
        [JsonPropertyName("code")]
        public string Code { get; private set; }

        /// <summary>
        /// redirect_uri
        /// 
        /// The "redirect_uri" that was provided in the Authorization step
        /// </summary>
        /// <value></value>
        [JsonPropertyName("redirect_uri")]
        public string RedirectUri { get; private set; }

    }
}
