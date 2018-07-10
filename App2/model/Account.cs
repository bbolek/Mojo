using System;
using App2.Utils;
using Newtonsoft.Json;

namespace App2.model
{
    public class Account : Mojo
    {
        public MojoReference contact { get; set; }
    }
}