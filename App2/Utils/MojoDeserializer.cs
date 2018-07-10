using System;
using System.Collections.Generic;
using System.Linq;
using App2.model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace App2.Utils
{
    public class MojoDeserializer : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var t = JToken.FromObject(value);

            if (t.Type != JTokenType.Object)
            {
                t.WriteTo(writer);
            }
            else
            {
                var o = (JObject)t;
                IList<string> propertyNames = o.Properties().Select(p => p.Name).ToList();

                o.AddFirst(new JProperty("Keys", new JArray(propertyNames)));

                o.WriteTo(writer);
            }
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var obj = JObject.Load(reader);
            var req = obj.ToObject(objectType) as MojoRequest;
            if (req.objectName == "Mojo")
            {
                var mojo = req.data.ToObject<Mojo>();
                if (mojo.attributeList == null || mojo.attributeList.Count <= 0) return req;
                foreach (var attribute in mojo.attributeList)
                {
                    if (attribute.name == "contact")
                    {
                        attribute.value = JsonConvert.DeserializeObject<MojoReference>(attribute.value.ToString());
                    }
                }

                req.obj = mojo;
            }
            
            Console.Write(req);
            
            return req;
        }

        public override bool CanConvert(Type objectType)
        {
            return true;
        }
    }
}