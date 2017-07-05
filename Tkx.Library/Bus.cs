using System;
using System.Collections.Generic;
using System.Text;

namespace Tkx.Library
{
   public  class Bus
    {

        public Tkx.DbBase.ApiLog apiLog = new DbBase.ApiLog();



        /// <summary>判断接口的访问上限
        /// </summary>
        /// <param name="controller">控制器</param>
        /// <param name="action">方法名</param>
        /// <returns></returns>
        public  bool InterfaceCount(string controller, string action)
        {

            string cName = string.Format("{0}/{1}", controller, action);
Tkx.Model.ApiLogModel ap= apiLog.ApiCountSel(cName, DateTime.Now);


          


            if (ap.ap_Id == 0)
            {
                apiLog.ApiCountAdd(cName, 1, DateTime.Now);
                return true;

            }
            else
            {
                if (ap.ap_maxcount > ap.ap_count) {
                    apiLog.ApiCountUpdate(ap.ap_Id); return true;
                }
                return false;
               
            } 
        }

    }
}
