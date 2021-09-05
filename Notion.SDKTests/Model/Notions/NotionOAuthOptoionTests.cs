using Microsoft.VisualStudio.TestTools.UnitTesting;
using Notion.SDK.Model.Options;
using System.Web;

namespace Notion.SDK.Model.Notions.Tests
{
    [TestClass()]
    public class NotionOAuthOptoionTests
    {
        [TestMethod()]
        public void ToAuthorizationURLTest()
        {
            var clientId = "463558a3-725e-4f37-b6d3-0889894f68de";
            var redurectUrl = "https://example.com/auth/notion/callback";
            var option = new OAuthOptoion(clientId, redurectUrl);
            var url = option.ToAuthorizationURL();
            var excpeted = $"https://api.notion.com/v1/oauth/authorize?client_id={clientId}&redirect_uri={HttpUtility.UrlEncode(redurectUrl)}&response_type=code&stste=";
            Assert.AreEqual(excpeted, url);
        }
    }
}