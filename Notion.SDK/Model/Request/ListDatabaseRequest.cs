using Notion.SDK.Model.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notion.SDK.Model.Request
{
    public class ListDatabaseRequest : NotionBaseRequest<ListDatabaseContent, ListDatabaseResponse>
    {
        public ListDatabaseRequest(string token) : base(token)
        {

        }

        protected override string Uri => "databases";

        protected override HttpMethod Method => HttpMethod.Get;
    }


    public class ListDatabaseContent : PagingRequest
    {

    }
}
