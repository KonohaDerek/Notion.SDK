using Notion.SDK.Model.Enums;
using System.Text.Json.Serialization;

namespace Notion.SDK.Model.Objects
{
    public class SortObject
    {
        /// <summary>
        /// The name of the property to sort against.
        /// </summary>
        [JsonPropertyName("property")]
        public string Property { get; set; }

        /// <summary>
        /// The name of the timestamp to sort against. Possible values include "created_time" and "last_edited_time". 
        /// </summary>
        [JsonPropertyName("timestamp")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public EnumSortTimestamp Timestamp { get; set; }

        /// <summary>
        /// The direction to sort. Possible values include "ascending" and "descending".
        /// </summary>
        [JsonPropertyName("direction")]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public string Direction { get; set; }

    }
}
