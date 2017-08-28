using System;
using System.Collections.Generic;
using System.Text;

namespace Tkx.Library
{
   public  class Bus
    {
		///����ռ�
        public Tkx.DbBase.ApiLog apiLog = new DbBase.ApiLog();



        /// <summary>�жϽӿڵķ�������
        /// </summary>
        /// <param name="controller">������</param>
        /// <param name="action">������</param>
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
