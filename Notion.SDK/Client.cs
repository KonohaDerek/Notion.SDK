using Notion.SDK.Model.Objects;
using Notion.SDK.Model.Request;
using Notion.SDK.Model.Response;
using System.ComponentModel.DataAnnotations;

namespace Notion.SDK;
public class Client
{
    [Required]
    private string AccessToken;

    public Client(string token)
    {
        this.AccessToken = token;
    }

    public void QueryDatabase(string databaseId , QueryDatabaseContent query)
    {
        // 檢查 Token
        if (string.IsNullOrWhiteSpace(AccessToken))
        {
            throw new ArgumentNullException(nameof(AccessToken), "you need set token first");
        }

        var request = new QueryDatabaseRequest(AccessToken , databaseId);
        request.Content = query;

    }


    public void CreateDatabase()
    {

    }


    public async Task<ListDatabaseResponse?> ListDatabasesAsync(ListDatabaseContent query)
    {  
        // 檢查 Token
        if (string.IsNullOrWhiteSpace(AccessToken))
        {
            throw new ArgumentNullException(nameof(AccessToken), "you need set token first");
        }

        var request = new ListDatabaseRequest(AccessToken);
        request.Content = query;
        return await request.ExcuteAsync();

    }


    public static async Task<AuthorizeObject?> AuthorizationCodeAsync(string code, string redirect_uri)
    {
        var request = new AuthorizationCodeRequest(code, redirect_uri);
        return await request.ExcuteAsync();
    }
}
