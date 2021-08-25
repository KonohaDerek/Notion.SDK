namespace Notion.SDK.Model.Request
{
    public abstract class NotionBaseRequest<TContent , TResponse>
    {

        public abstract string Uri { get; }

        public abstract HttpMethod Method { get; }

        public virtual string ContentType => "application/json";

        public TContent? Content { get; set; }

        public virtual async Task<TResponse?> ExcuteAsync(string token)
        {
            var requestUri = new Uri(new Uri("https://api.notion.com/v1/"), Uri);
            var request = new HttpRequestMessage(this.Method, requestUri)
            {
                Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(this.Content))
            };
            request.Headers.Add("Notion-Version", "2021-08-16");
            request.Headers.Add("Content-Type", ContentType);
            request.Headers.Add("Authorization", token);
            var client = new HttpClient();
            var response = await client.SendAsync(request);
            if(response != null && response.IsSuccessStatusCode)
            {
                return default;
            }
            else
            {
                throw new Exception($"Call Api Faild , code : {response?.StatusCode} , msg: {response?.Content}");
            }
        }
    }
}
