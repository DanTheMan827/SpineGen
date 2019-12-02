using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace SpineGen.JSON
{
    public class RectangleConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Width");
            serializer.Serialize(writer, ((Rectangle)value).Width);
            
            writer.WritePropertyName("Height");
            serializer.Serialize(writer, ((Rectangle)value).Height);

            writer.WritePropertyName("X");
            serializer.Serialize(writer, ((Rectangle)value).X);

            writer.WritePropertyName("Y");
            serializer.Serialize(writer, ((Rectangle)value).Y);
            writer.WriteEndObject();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var rect = serializer.Deserialize<Dictionary<string, int>>(reader);
            return new Rectangle(rect["X"], rect["Y"], rect["Width"], rect["Height"]);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(Dictionary<string, int>);
        }
    }
}
