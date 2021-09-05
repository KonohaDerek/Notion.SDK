using Notion.SDK.Model.Objects;
using Notion.SDK.Model.Response;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Notion.SDK.Model.Request
{
    public class QueryDatabaseRequest :NotionBaseRequest<QueryDatabaseContent, QueryDatabaseResponse>  
    {

        public QueryDatabaseRequest(string token , string databaseId): base(token)
        {
            DatabaseId = databaseId;
        }


        private string DatabaseId { get; }

        protected override string Uri => $"databases/{DatabaseId}/query";

        protected override HttpMethod Method => HttpMethod.Post;
    }

    public class QueryDatabaseContent : PagingRequest
    {
        [JsonPropertyName("filter")]
        public JsonObject Filter { get; set; }

        [JsonPropertyName("sorts")]
        public List<SortObject> Sorts { get; set; }
    }
}
