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
    public class RoleController : BaseController
    {
        short delFlagNormal = (short)ViewModel.Enum.DelFlagEnum.Normal;
        private readonly ILogger<RoleController> _logger;//处理日志相关文件

        private Iinfo_roleBll _info_RoleBll;
        public RoleController(ILogger<RoleController> logger, Iinfo_roleBll info_RoleBll)
        {
            _logger = logger;
            _info_RoleBll = info_RoleBll;
        }
        [HttpGet]//得到所有角色(有效角色)
        public IActionResult getRoles()
        {
            var data = _info_RoleBll.GetAllEntities().AsNoTracking();
            var mydata = (from r in data
                          where r.is_delete == delFlagNormal
                          select r).ToList();
          return  Content(JsonHelper.JsonToString(mydata));
        }

        [HttpGet]//通过角色id得到该角色的权限
        public async  Task<IActionResult> GetActionByRoleId(int roleId)
        {
            var roles = await _info_RoleBll.GetEntities(u => u.Id == roleId).Include(u=>u.Info_Actions).FirstOrDefaultAsync();
            var actions = roles.Info_Actions;
            var mydata = (from r in actions
                          where r.is_delete == delFlagNormal
                          select new { 
                          r.Id,
                          r.action_name
                          }).ToList();
            return Content(JsonHelper.JsonToString(mydata));
        }

        [HttpPost]//设置角色拥有哪些权限
        public async Task<IActionResult> setAction(setByIds mySetAction)
        {
         var data=   await _info_RoleBll.setAction(mySetAction.Id, mySetAction.Ids);
            return Content(JsonHelper.JsonToString(data));
        }

        [HttpPost]//添加角色
        public IActionResult AddRole(info_role data)
        {
            return Content(JsonHelper.JsonToString(_info_RoleBll.Add(data)));
        }

        [HttpGet]//根据roleid删除角色(逻辑删除)
        public IActionResult DelRole(int roleId)
        {
            var user = _info_RoleBll.GetEntities(u => u.Id == roleId).FirstOrDefault();
            user.is_delete = (short)ViewModel.Enum.DelFlagEnum.Deleted;
            return Content(JsonHelper.JsonToString(_info_RoleBll.Update(user)));
        }

        [HttpPost]//修改角色
        public async Task<IActionResult> UpdateRole(info_role _info_Role)
        {
            var role = await _info_RoleBll.GetEntities(u => u.Id == _info_Role.Id).FirstOrDefaultAsync();
            role.role_name = _info_Role.role_name;
            var flag = _info_RoleBll.Update(role);
            return Content(JsonHelper.JsonToString(null, flag: flag));
        }
        [HttpPost]//多角色逻辑删除
        public async Task<IActionResult> DelAllRole(List<int> Ids)
        {
            return Content(JsonHelper.JsonToString(null, flag: await _info_RoleBll.DelALLByUpdateList(Ids)));
        }
    }
}
