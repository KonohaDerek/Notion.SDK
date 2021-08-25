using System.Text.Json.Serialization;

namespace Notion.SDK.Model.Request
{
    public abstract class PagingRequest
    {
        [JsonPropertyName("start_cursor")]
        public int PageCount { get; set; } = 0;

        [JsonPropertyName("page_size")]
        public int PageSize { get; set; } = 100;
    }
}
