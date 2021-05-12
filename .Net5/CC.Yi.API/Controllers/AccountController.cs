using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CC.Yi.Model;
using CC.Yi.IBLL;
using CC.Yi.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CC.Yi.API.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class AccountController : BaseController
    {
        private Iinfo_userBll _info_UserBll;
        private ILogger<AccountController> _logger;
        public AccountController(Iinfo_userBll info_UserBll, ILogger<AccountController> logger)
        {
            IsCheck = 0;
            _info_UserBll = info_UserBll;
            _logger = logger;
        }

        [HttpPost]//验证登录
        public async Task<IActionResult> login(info_user _info_user)
        {
            var data = await _info_UserBll.GetEntities(u => u.user_name == _info_user.user_name && u.is_delete == (short)ViewModel.Enum.DelFlagEnum.Normal).AsNoTracking().Select(r => new { r.Id, r.user_name, r.password }).FirstOrDefaultAsync();

            if (data != null)
            {
                if (data.password == _info_user.password)
                {
                    HttpContext.Session.SetString("loginId", JsonHelper.ToString(_info_user));
                    _logger.LogInformation(_info_user.user_name + "登录成功!");
                    return Content(JsonHelper.JsonToString(data));
                }
            }

            _logger.LogInformation(_info_user.user_name + "登录失败!");
            return Content(JsonHelper.JsonToString(null, flag: false, message: "用户名或密码错误"));
        }
        [HttpPost]//退出登入
        public IActionResult logOff()
        {
            var data = HttpContext.Session.GetString("loginId");
            string user_name = JsonHelper.ToUser(data).user_name;
            _logger.LogInformation(user_name + "已退出登录!");
            HttpContext.Session.Clear();
            return Content(JsonHelper.JsonToString(null));
        }
        [HttpPost]//判断session是否过期
        public ActionResult Logged()
        {
            var data = HttpContext.Session.GetString("loginId");

            if (data == null)//表示登入已经过期
            {
                return Content(JsonHelper.JsonToString(null, flag: false, message: "登录已过期"));
            }
            else
            {
                return Content(JsonHelper.JsonToString(null));//session没有过期
            }

        }
        [HttpPost]//注册
        public async Task<IActionResult> Register(info_user _info_user)
        {
            var user = await _info_UserBll.GetEntities(u => u.user_name == _info_user.user_name).FirstOrDefaultAsync();
            if (user == null)
            {
                var data = _info_UserBll.Add(_info_user);
                if (await _info_UserBll.setRole(data.Id, new List<int> { 1 }))
                {
                    _logger.LogInformation(_info_user.user_name + "注册成功!");
                    return Content(JsonHelper.JsonToString(null, message: "注册成功"));
                }
                else
                {
                    _logger.LogInformation(_info_user.user_name + "游客角色添加失败!");
                    return Content(JsonHelper.JsonToString(null, flag: false, message: "游客角色添加失败!"));
                }

            }
            else
            {
                _logger.LogInformation(_info_user.user_name + "注册失败!");
                return Content(JsonHelper.JsonToString(null, flag: false, message: "当前用户已被注册"));
            }


        }

    }
}
