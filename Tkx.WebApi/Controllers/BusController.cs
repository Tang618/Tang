using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tkx.Model;
using Tkx.Common;

namespace Tkx.WebApi.Controllers
{

    // [Produces("application/json")]
    [Route("api/Bus")]
    public class BusController : SampleActionFilter
    {
        //这块以后封装到Redis
        
        public static List<string> Tokens = new List<string>();

        [Route("GetText")]
        [HttpGet]
        public IEnumerable<string> GetText()
        {
            return new string[] { "value1", "value2" };
        }

        [Route("tokenID")]
        [HttpGet]
        public Errcode tokenID(string Appid,string AppKey)
        {
            string mess = "test";
            if (Appid == "and" && AppKey == "cf0cf1b9b5de40c5b7b72d0b349d577d")
            {
                mess = Tools.CreateGUID();
                Tokens.Add(mess);
                return ResultSet(ErrcodeType.请求成功, mess, null); 
            }

            return ResultSet(ErrcodeType.令牌无效, mess, null); 
        }
    }
}