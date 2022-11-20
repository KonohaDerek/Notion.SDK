using Notion.SDK.Model.Response;
using System.Net.Http;
using System.Text.Json.Serialization;

namespace Notion.SDK.Model.Request
{
    public class SearchRequest : NotionBaseRequest<SearchContent, SearchResponse>
    {
        public SearchRequest(string token) : base(token)
        {

        }

        protected override string Uri => "search";

        protected override HttpMethod Method => HttpMethod.Post;
    }


    public class SearchContent : PagingRequest
    {
        [JsonPropertyName("query")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Query { get; set; }

    }
}
