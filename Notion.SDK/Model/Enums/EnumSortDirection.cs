using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Notion.SDK.Model.Enums
{
    public enum EnumSortDirection
    {
        [EnumMember(Value = "ascending")]
        ASC,

        [EnumMember(Value = "descending")]
        DESC
    }
}
