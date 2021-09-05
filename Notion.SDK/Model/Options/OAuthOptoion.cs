using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Notion.SDK.Model.Options
{
    public class OAuthOptoion
    {
        public OAuthOptoion(string clientId, string redurectUrl, string state = "")
        {
            ClientId = clientId;
            RedurectUrl = redurectUrl;
            State = state;
        }

        /// <summary>
        /// client_id
        /// 
        /// An identifier for your integration, found in the integration settings
        /// </summary>
        /// <value></value>
        private string ClientId { get; set; }

        /// <summary>
        /// redirect_uri
        /// 
        /// A URL where the user should return after granting access. This is described in detail below.
        /// </summary>
        /// <value></value>
        private string RedurectUrl { get; set; }

        /// <summary>
        /// response_type
        /// 
        /// Always use code
        /// </summary>
        private string ResponseType => "code";


        /// <summary>
        /// state
        /// 
        /// If the user was in the middle of an interaction or operation, this parameter can be used to restore state after the user returns. It is also can be used to prevent CSRF attacks.
        /// </summary>
        /// <value></value>
        private string State { get; set; }


        public string ToAuthorizationURL()
        {
            return $"https://api.notion.com/v1/oauth/authorize?client_id={ClientId}&redirect_uri={HttpUtility.UrlEncode(RedurectUrl)}&response_type={ResponseType}&stste={State}";
        }
    }
}
