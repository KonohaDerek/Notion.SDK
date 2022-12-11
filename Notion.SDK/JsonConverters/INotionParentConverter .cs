using Notion.SDK.Model.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Notion.SDK.JsonConverters
{
    public class INotionParentConverter : JsonConverter<INotionParent>
    {
        public override INotionParent Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            throw new NotImplementedException();
        }

        public override void Write(Utf8JsonWriter writer, INotionParent value, JsonSerializerOptions options)
        {
            if (value is DatabaseObject)
                JsonSerializer.Serialize(writer, value as DatabaseObject, typeof(DatabaseObject), options);
            else
                throw new ArgumentOutOfRangeException(nameof(value), $"Unknown implementation of the interface {nameof(INotionParent)} for the parameter {nameof(value)}. Unknown implementation: {value?.GetType().Name}");
        }
    }
}
