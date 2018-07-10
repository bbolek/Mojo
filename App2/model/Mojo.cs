using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using App2.Services.Database;
using Microsoft.IdentityModel.Xml;

namespace App2.model
{
    public class Mojo : ISerializable
    {
        public string name { get; set; }
        public long id { get; set; }
        public Dictionary<string, MojoAttribute> attributes { get; } = new Dictionary<string, MojoAttribute>();

        public void save()
        {
            DBService.Instance.InsertMojo(this);
        }
        
        public object this[string attrName]
        {
            get
            {
                if (this.attributes.ContainsKey(attrName))
                {
                    return this.attributes[attrName];
                }
                else
                {
                    throw new Exception("Attribute " + attrName + " not found!");
                }            }
            set
            {
                if (this.attributes.ContainsKey(attrName))
                {
                    this.attributes[attrName].value = value;
                }
                else
                {
                    throw new Exception("Attribute " + attrName + " not found!");
                }
                
            }
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            Console.Write(info);
        }
    }
}