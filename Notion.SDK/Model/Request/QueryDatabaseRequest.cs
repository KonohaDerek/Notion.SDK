using Notion.SDK.Model.Notions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Notion.SDK.Model.Request
{
    public class QueryDatabaseRequest : PagingRequest
    {


        [JsonPropertyName("filter")]
        public JsonObject Filter { get; set; }

        [JsonPropertyName("sorts")]
        public List<SortObject> Sorts { get; set; }

    }
}
