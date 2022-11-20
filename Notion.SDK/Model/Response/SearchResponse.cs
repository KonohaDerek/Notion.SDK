using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Notion.SDK.Model.Response
{
    public class SearchResponse
    {
        [JsonPropertyName("object")]
        public string Name { get; set; }

        //[JsonPropertyName("results")]
        //public List<SearchObject> Results { get; set; }

        [JsonPropertyName("next_cursor")]
        public string NextCursor { get; set; }

    }
}
