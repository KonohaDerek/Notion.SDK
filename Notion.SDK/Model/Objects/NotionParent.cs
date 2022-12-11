using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Notion.SDK.Model.Objects
{
    public interface INotionParent
    {
    }

    public class DatabaseObject : INotionParent
    {
        //[JsonPropertyName("object")]
        //public string Object => "database";

        [JsonPropertyName("database_id")]
        public string ID { get; set; } = "";

        //[JsonPropertyName("created_time")]
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        //public string? CreatedTime { get; set; }

        //[JsonPropertyName("created_by")]
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        //public IPartialUserObject? CreatedBy { get; set; }


        //[JsonPropertyName("last_edited_time")]
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        //public string? LastEditedTime { get; set; }

        //[JsonPropertyName("last_edited_by")]
        //[JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        //public IPartialUserObject? LastEditedBy { get; set; }
    }
}
