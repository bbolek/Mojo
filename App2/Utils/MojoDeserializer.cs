using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace App2.Utils
{
    public class MojoDeserializer<Mojo> : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.Null:
                    return string.Empty;
                case JsonToken.String:
                    return serializer.Deserialize(reader, objectType);
                default:
                    var obj = JObject.Load(reader);
                    return obj["Code"] != null ? obj["Code"].ToString() : serializer.Deserialize(reader, objectType);
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}