using System;
using System.Collections.Generic;
using System.Text;




namespace Tkx.Library
{ 


    /*全局定义点 */

    /// <summary>支付类型    
    ///0：现金      
    ////1：自助缴费终端
    ///2：手持终端
    ///3：中心缴费
    ////4：停开心余额         
    ///5：微信         
    ////6：支付宝
    ///7：银联 
    ///8：抵扣
    ///9：其他   
    /// </summary>
    public enum Enum_payMethod
    {
        现金 = 0,
        自助缴费终端 = 1,
        手持终端 = 2,
        中心缴费 = 3,
        停开心余额 = 4,
        微信 = 5,
        支付宝 = 6,
        银联 = 7,
        抵扣8,
        其他 = 9
    }


    public enum Enum_PaymentStatus
    {
       待支付 =0,
       支付=1,
       支付完成=2,
       退款=3

    }
}
