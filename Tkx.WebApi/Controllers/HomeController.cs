using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Tkx.Model;
using Tkx.Common;

namespace Tkx.WebApi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            Tkx.Common.Tools.MessBox("test");
            return View();
        }

      
        public IActionResult Error()
        {
            return View();
        }

        /// <summary>获取令牌
        /// 
        /// </summary>
        /// <returns></returns>
        public string GetToken()
        {
           

          var k=  Tools.CreateGUID();

             string par = "appid=and&appke=sdfasdf";
            string nn;
                
               // nn=    AjaxJson.HttpPost("http://localhost:51325/api/bus/tokenID", System.Text.Encoding.UTF8, 1000, "temp", "moblie", "2.0", DateTime.Now.ToString("yyyyMMddssmmdd"),"0","12.1.1.","safsdf", key);


              nn = AjaxJson.HttpGet("http://localhost:51325/api/bus/tokenID?appid=and&appkey=cf0cf1b9b5de40c5b7b72d0b349d577d", System.Text.Encoding.UTF8);


            Errcode err = Newtonsoft.Json.JsonConvert.DeserializeObject<Errcode>(nn);
            if (err.errcodeType == ErrcodeType.请求成功)
            {
                nn = err.Mess;
            }
            else
            {
                nn = "无法获取令牌";
            }

            return nn;
        }


        /// <summary>加密测试
        /// 
        /// </summary>
        /// <returns></returns>
        public string CreateKey()
        {
            return "加密测试";
        }




        /// <summary>模拟提交
        /// 
        /// </summary>
        /// <returns></returns>
        public string Tpost()
        {
            return "模拟提交";
        }




        /// <summary>后期树的数据
        /// 
        /// </summary>
        /// <returns></returns>
        public List<TreeDataFormatModel> TreeData()
        {


            List<TreeDataFormatModel> li = new List<TreeDataFormatModel>();

            TreeDataFormatModel T = new TreeDataFormatModel();
           


            T = new TreeDataFormatModel();
            T.id = 2;
            T.text = "所有分类";
           // T.state = TreeState.open.ToString();
            T.attributes = " ";

          //  T.children = new List<TreeDataFormatModel>();

            //T.children = new List<TreeDataFormatModel>() {
            //    new TreeDataFormatModel() { id = 20, text = "公共模块Bus", attributes = " " },
            //    new TreeDataFormatModel() { id = 21, text = "会员Account", attributes = " " },
            //    new TreeDataFormatModel() { id = 22, text = "医院Hospital", attributes = " " },
            //};

            li.Add(T);


            //JsonResult js = new JsonResult();
     
            //js.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            return li;
        }
    }
}
