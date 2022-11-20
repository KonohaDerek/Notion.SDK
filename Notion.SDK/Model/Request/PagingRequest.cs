using System.Text.Json.Serialization;

namespace Notion.SDK.Model.Request
{
    public abstract class PagingRequest
    {
        [JsonPropertyName("start_cursor")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? StartCursor { get; set; }

        //[JsonPropertyName("page_count")]
        //public int PageCount { get; set; } = 1;

        [JsonPropertyName("page_size")]
        public int PageSize { get; set; } = 100;
    }
}
