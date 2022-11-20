using System.Text.Json.Serialization;

namespace Notion.SDK.Model.Objects
{
    public class AuthorizeObject
    {

        /// <summary>
        /// access_token
        /// 
        /// An access token used to authorize requests to the Notion API.
        /// </summary>
        /// <value></value>

        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }  = string.Empty;

        /// <summary>
        /// workspace_id
        /// 
        /// The ID of the workspace where this authorization took place.
        /// </summary>
        /// <value></value>
        [JsonPropertyName("workspace_id")]
        public string WorkspaceId { get; set; } = string.Empty;

        /// <summary>
        /// workspace_name
        /// 
        /// A human-readable name which can be used to display this authorization in UI.
        /// </summary>
        /// <value></value>
        [JsonPropertyName("workspace_name")]
        public string WorkspaceName { get; set; }  = string.Empty;


        /// <summary>
        /// workspace_icon
        /// 
        /// A URL to an image which can be used to display this authorization in UI.
        /// </summary>
        /// <value></value>
        [JsonPropertyName("workspace_icon")]
        public string WorkspaceIcon { get; set; } = string.Empty;


        /// <summary>
        /// bot_id
        /// 
        /// An identifier for this authorization.
        /// </summary>
        /// <value></value>
        [JsonPropertyName("bot_id")]
        public string BotId { get; set; } = string.Empty;

        /// <summary>
        /// owner
        /// 
        /// An object containing information about who can view and share this integration. Always { "workspace": true } for now.
        /// </summary>
        /// <value></value>
        [JsonPropertyName("owner")]
        public object? Owner { get; set; }
    }
}
