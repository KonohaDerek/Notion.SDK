using Notion.SDK.JsonConverters;
using Notion.SDK.Model.Objects;
using Notion.SDK.Model.Response;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Notion.SDK.Model.Request
{
    public class CreatePageRequest : NotionBaseRequest<CreatePageContent, CreatePageResponse>
    {
        public CreatePageRequest(string token , string databaseId) : base(token)
        {
            this.Content = new CreatePageContent()
            {
                Parent = new DatabaseObject()
                {
                    ID = databaseId,
                }
            };
        }

        protected override string Uri => "pages";

        protected override HttpMethod Method => HttpMethod.Post;
    }


    public class CreatePageContent
    {
        [JsonPropertyName("parent")]
        [JsonConverter(typeof(INotionParentConverter))]
        [Required]
        public INotionParent Parent { get; set; }

        [JsonPropertyName("properties")]
        public Dictionary<string, object> Properties { get; set; } = new Dictionary<string, object>();

        [JsonPropertyName("children")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public string? Children { get; set; }

        [JsonPropertyName("icon")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public NotionIconObject? Icon { get; set; }

        [JsonPropertyName("cover")]
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public NotionCoverObject? Cover { get; set; }
    }

    public class CreatePageResponse
    {
        [JsonPropertyName("object")]
        public string Object { get; set; }

        [JsonPropertyName("status")]
        public int Status { get; set; }

        [JsonPropertyName("code")]
        public string Code {  get; set; }

        [JsonPropertyName("message")]
        public string Message { get; set; }

        [JsonPropertyName("id")]
        public Guid? ID { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }
    }
}
