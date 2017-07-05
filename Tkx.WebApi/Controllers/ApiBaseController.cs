using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Tkx.Model;

namespace Tkx.WebApi.Controllers
{

 

    /// <summary>获取监控指标日志
    /// 
    /// </summary>
    public class SampleActionFilter : Controller,IActionFilter , IAuthorizationFilter
    {

       Tkx.Library.Bus bus = new Library.Bus();

      

        private DateTime dt_S;
        /// <summary>执行前
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            string action = context.ActionDescriptor.RouteValues["action"];
            string controller = context.ActionDescriptor.RouteValues["controller"]; 

            if (!bus.InterfaceCount(controller, action))
            {
                context.Result = Content(Newtonsoft.Json.JsonConvert.SerializeObject(ResultSet(ErrcodeType.系统繁忙, "", null)));  
            }

            dt_S = DateTime.Now;
        }
        /// <summary>执行后
        /// 
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuted(ActionExecutedContext context)
        {


            //  var queryStrings = context.HttpContext.Request.Query.Keys;


            //System.Text.StringBuilder sb = new System.Text.StringBuilder();
            //foreach (var item in queryStrings)
            //{
            //    sb.Append(item);
            //}

            //   Microsoft.AspNetCore.Mvc.ObjectResult
       
            var ss = context.Result.GetType();


            

          string action = context.ActionDescriptor.RouteValues["action"];
            string controller = context.ActionDescriptor.RouteValues["controller"];
            String Lg_Url="";
            String Lg_Type="页面加载";
            String Lg_Title = string.Format("{0}/{1}",controller,action);
            String Lg_Text; 
            String Lg_Token;
            String Lg_name = context.HttpContext.Request.QueryString.Value;
            String Lg_ip;
            String Lg_Bak;
            Int32 Lg_state;
            String Lg_Version;
            String Lg_Platform;
            String Lg_Area;

            TimeSpan TS= DateTime.Now.Subtract(dt_S);
            Int32 Lg_TimeOut = TS.Milliseconds ;

          //  (DateTime.Now - dt_S).TotalMilliseconds

          // bus.apiLog.add(Lg_Url, Lg_Type, Lg_Title, Lg_Text, DateTime.Now, Lg_Token, Lg_name, Lg_ip, Lg_Bak, Lg_state, Lg_Version, Lg_Platform, Lg_Area, Lg_TimeOut);

            //string controName = Name[0]["Key"];
        }
     

        /// <summary>
        /// 获取Action 参数
        /// </summary>
        /// <param name="Collections"></param>
        /// <returns></returns>
        public string GetCollections(Dictionary<string, object> Collections)
        {
            string Parameters = string.Empty;
            if (Collections == null || Collections.Count == 0)
            {
                return Parameters;
            }
            foreach (string key in Collections.Keys)
            {
                Parameters += string.Format("{0}={1}&", key, Collections[key]);
            }
            if (!string.IsNullOrWhiteSpace(Parameters) && Parameters.EndsWith("&"))
            {
                Parameters = Parameters.Substring(0, Parameters.Length - 1);
            }
            return Parameters;
        }

        /// <summary>
        /// 获取IP
        /// </summary>
        /// <returns></returns>
        public string GetIP()
        {
            string ip = string.Empty;
            ip = "127.0.0.1";
            return ip;
        }
        /// <summary>统一返回集合 
        /// </summary>
        /// <returns></returns>
        protected Errcode ResultSet(ErrcodeType er,bool isShow,string Mess, DataMode da)
        {
            Errcode e = new Errcode();
            e.errcodeType = er;
            e.isShow = isShow;
            e.Mess = Mess;
            e.Data = da; 
            return e; 
        }
        /// <summary>统一返回集合 
        /// </summary>
        /// <returns></returns>
        protected Errcode ResultSet(ErrcodeType er, string Mess, DataMode da)
        {

            return ResultSet(er, true, Mess, da);
        }

        /// <summary>商家授权验证类 
        /// </summary>
        /// <param name="context"></param>
        public void OnAuthorization(AuthorizationFilterContext context)
        {
          //  throw new NotImplementedException();
        }
    }


    
   
}