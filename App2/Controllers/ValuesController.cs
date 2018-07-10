using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using App2.model;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
namespace App2.Controllers
{
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost]
        [Route("/mojo")]
        public void Insert([FromBody] MojoRequest request)
        {
            //mojo.contact = JsonConvert.DeserializeObject<MojoReference>(mojo.attributes["contact"].value.ToString());
            try
            {
                //var acc = JsonConvert.DeserializeObject<Account>(JsonConvert.SerializeObject(mojo));
                //acc.save();
                /*mojo.id = 3;
                if (mojo.name == "account")
                {
                    Account acc = (Account) mojo;
                    acc.save();
                }
                else
                {
                    mojo.save();
                }*/
            }
            catch (Exception e)
            {
                Console.Write(e);
            }
        }

    }
}