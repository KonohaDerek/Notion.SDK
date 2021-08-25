
using Notion.SDK.Model.Notions;
using Notion.SDK.Model.Request;

namespace Notion.SDK;
public class Client
{

    private string AccessToken;

    public Client(NotionClientOption option)
    {

    }


    public Client(string base64str)
    {

    }

    public void SetAccessToken(string token)
    {
        AccessToken = token;
    }


    public void QueryDatabase(QueryDatabaseRequest query)
    {
        // 檢查 Token
        if(string.IsNullOrWhiteSpace(AccessToken))
        {
            throw new ArgumentNullException(nameof(AccessToken));
        }

        



    }

}
