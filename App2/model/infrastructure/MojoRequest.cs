using System;
using System.Runtime.Serialization;
using Newtonsoft.Json.Linq;

namespace App2.model
{
    public class MojoRequest
    {
        public string type { get; set; }
        public string objectName { get; set; }
        public JObject data { get; set; }
        public DateTime requestDate { get; set; }
        public string username { get; set; }
        public object obj { get; set; }
    }
}