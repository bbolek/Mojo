using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using App2.Services.Database;
using Microsoft.IdentityModel.Xml;

namespace App2.model
{
    public class Mojo : BaseObject
    {
        public string mojoType { get; set; }
        public long id { get; set; }
        public Dictionary<string, MojoAttribute> attributes { get; } = new Dictionary<string, MojoAttribute>();
        public List<MojoAttribute> attributeList { get; } = new List<MojoAttribute>();
        public Dictionary<string, Mojo> relationshipInfo { get; } =new Dictionary<string, Mojo>();
        
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

        public MojoAttribute getAttribute(string attr)
        {
            if (attributes.ContainsKey(attr))
            {
                return attributes["attr"];
            }
            throw new Exception("Attribute " + attr + " not found!");
        }

        public T getValue<T>(string attr)
        {
            if (attributes.ContainsKey(attr))
            {
                return (T) (object)attributes[attr].value;
            }
            throw new Exception("Attribute " + attr + " not found!");
        }
        
        public bool getBool(string attr)
        {
            return bool.Parse(this[attr].ToString());
        }
        
        public string getString(string attr)
        {
            return this[attr].ToString();
        }
    }
}