using CC.Yi.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Yi.API.Controllers
{
    public class BaseController: Controller
    {
        public int IsCheck = 1;//设置是否需要校验用户是否登录属性
        public int loginId = -1;

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            switch (IsCheck)
            {
                case 1://表示学生获得教师登入需要检验
                    var myUser =HttpContext.Session.GetString("loginId");
                    if (myUser != null)//表示已经登入过
                    {
                        loginId =Convert.ToInt32(JsonHelper.ToUser(myUser).Id);
                    }
                    else
                    {
                        filterContext.Result = Content(JsonHelper.JsonToString(null,flag:false,message:"登录超时"));
                    }
                    break;
                case 0:
                    return;
            }
        }
    }
}
