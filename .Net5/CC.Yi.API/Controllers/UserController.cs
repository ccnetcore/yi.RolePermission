using CC.Yi.Common;
using CC.Yi.IBLL;
using CC.Yi.Model;
using CC.Yi.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Yi.API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : BaseController
    {

        private readonly ILogger<UserController> _logger;//处理日志相关文件

        private Iinfo_userBll _info_UserBll;
        public UserController(ILogger<UserController> logger, Iinfo_userBll info_UserBll)
        {
            _logger = logger;
            _info_UserBll = info_UserBll;
        }

        [HttpGet]//得到所有有效用户
        public async Task<IActionResult> getAllUser()
        {
            var data = await _info_UserBll.GetAllEntities().AsNoTracking().Where(u => u.is_delete == (short)ViewModel.Enum.DelFlagEnum.Normal).ToListAsync();
         
            return Content(JsonHelper.JsonToString(data));
        }

        [HttpGet]//得到用户所具有的全部权限：正常权限+特殊权限
        public async Task<IActionResult> getActionByUserId(int userId)
        {
            var data = await _info_UserBll.getActionByUserId(userId);
            return Content(JsonHelper.JsonToString(data));
        }
        [HttpGet]//得到用户所具有的特殊权限
        public async Task<IActionResult> getSpecialAction(int userId)
        {
            var data = await _info_UserBll.GetEntities(u => u.Id == userId).Include(u => u.Info_Actions).FirstOrDefaultAsync();
            var mydata = (from u in data.Info_Actions
                          where u.is_delete == (short)ViewModel.Enum.DelFlagEnum.Normal
                          select new { u.Id, u.action_name }).ToList();
            return Content(JsonHelper.JsonToString(mydata));
        }

        [HttpPost]//添加用户
        public IActionResult addUser(info_user _info_user)
        {
            var data = _info_UserBll.Add(_info_user);
            return Content(JsonHelper.JsonToString(null));
        }


        [HttpPost]//给用户设置角色
        public async Task<IActionResult> setRole(setByIds mySetRole)
        {
            return Content(JsonHelper.JsonToString(await _info_UserBll.setRole(mySetRole.Id, mySetRole.Ids)));
        }


        [HttpPost]//给用户设置特殊权限
        public async Task<IActionResult> setSpecialAction(setByIds mySetSpecialAction)
        {
            return Content(JsonHelper.JsonToString(await _info_UserBll.setSpecialAction(mySetSpecialAction.Id, mySetSpecialAction.Ids)));
        }
        [HttpPost]//多用户逻辑删除
        public async Task<IActionResult> DelAllUser(List<int> Ids)
        {
         return Content(JsonHelper.JsonToString(null, flag:await _info_UserBll.DelALLByUpdateList(Ids)));
        }

        [HttpGet]//根据userid删除用户(逻辑删除)
        public IActionResult DelUser(int userId)
        {
            var user = _info_UserBll.GetEntities(u => u.Id == userId).FirstOrDefault();
            user.is_delete = (short)ViewModel.Enum.DelFlagEnum.Deleted;
            return Content(JsonHelper.JsonToString(_info_UserBll.Update(user)));
        }
        [HttpPost]//修改用户
        public async Task<IActionResult> UpdateUser(info_user _info_user)
        {
            var user = await _info_UserBll.GetEntities(u => u.Id == _info_user.Id).FirstOrDefaultAsync();
            user.user_name = _info_user.user_name;
            user.password = _info_user.password;
            var flag = _info_UserBll.Update(user);
            return Content(JsonHelper.JsonToString(null, flag: flag));
        }
        [HttpGet]//通过Id得到该用户有哪些角色
        public async Task<IActionResult> getRoleByuserId(int userId)
        { 
        var user = await _info_UserBll.GetEntities(u => u.Id == userId).Include(u=>u.Info_Roles) .FirstOrDefaultAsync();
            var roles = (from u in user.Info_Roles
                         where u.is_delete == (short)ViewModel.Enum.DelFlagEnum.Normal
                         select new { u.Id,u.role_name}).ToList();


            return Content(JsonHelper.JsonToString(roles));
        }
    }
}
