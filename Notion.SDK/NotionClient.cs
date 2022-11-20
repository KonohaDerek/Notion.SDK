using Notion.SDK.Model.Objects;
using Notion.SDK.Model.Options;
using Notion.SDK.Model.Request;
using Notion.SDK.Model.Response;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace Notion.SDK;
public class NotionClient
{
    [Required]
    private string AccessToken;

    private readonly string ClientId;
    private readonly string ClientSecret;

    public NotionClient(string token)
    {
        this.AccessToken = token;
        ClientId = "";
        ClientSecret = "";
    }

    public NotionClient(string clientId, string clientSecret)
    {
        AccessToken = "";
        ClientId = clientId;
        ClientSecret= clientSecret;
    }

    public void QueryDatabase(string databaseId , QueryDatabaseContent query)
    {
        // 檢查 Token
        if (string.IsNullOrWhiteSpace(AccessToken))
        {
            throw new ArgumentNullException(nameof(AccessToken), "you need set token first");
        }

        var request = new QueryDatabaseRequest(AccessToken, databaseId)
        {
            Content = query
        };


    }

 
    public async Task<SearchResponse?> SearchAsync(SearchContent query)
    {  
        // 檢查 Token
        if (string.IsNullOrWhiteSpace(AccessToken))
        {
            throw new ArgumentNullException(nameof(AccessToken), "you need login first");
        }

        var request = new SearchRequest(AccessToken);
        request.Content = query;
        return await request.ExcuteAsync();
    }


    public string AuthorizationURL(string redirectUrl, string state = "")
    {
        var option = new OAuthOptoion(this.ClientId, redirectUrl);
        return option.ToAuthorizationURL();
    }

    public async Task<AuthorizeObject?> AuthorizationCodeAsync(string code, string redirect_uri)
    {
        var request = new AuthorizationCodeRequest(ClientId, ClientSecret, code, redirect_uri);
        var result = await request.ExcuteAsync();
        if (result != null)
            AccessToken = result.AccessToken;
        return await request.ExcuteAsync();
    }
}
