using CC.Yi.Common;
using CC.Yi.IBLL;
using CC.Yi.Model;
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
    public class ActionController : BaseController
    {
        short delFlagNormal = (short)ViewModel.Enum.DelFlagEnum.Normal;
        private readonly ILogger<ActionController> _logger;//处理日志相关文件
        private Iinfo_actionBll _info_ActionBll;
        public ActionController(ILogger<ActionController> logger,Iinfo_actionBll info_ActionBll)
        {
            _logger = logger;
            _info_ActionBll = info_ActionBll;
        }
        [HttpGet]//得到所有权限(有效权限)
        public async Task<IActionResult> getActions()
        {
            var data = _info_ActionBll.GetAllEntities().AsNoTracking();
            var mydata =await (from r in data
                          where r.is_delete == delFlagNormal
                          select r).ToListAsync();
            return Content(JsonHelper.JsonToString(mydata));
        }

        [HttpPost]//添加权限
        public IActionResult AddAction(info_action data)
        {
            return Content(JsonHelper.JsonToString(_info_ActionBll.Add(data)));
        }

        [HttpGet]//根据actionid删除权限(逻辑删除)
        public IActionResult DelAction(int actionId)
        {
            var user = _info_ActionBll.GetEntities(u => u.Id == actionId).FirstOrDefault();
            user.is_delete = (short)ViewModel.Enum.DelFlagEnum.Deleted;
            return Content(JsonHelper.JsonToString(_info_ActionBll.Update(user)));
        }
        [HttpPost]//修改权限
        public async Task<IActionResult> UpdateAction(info_action _info_Action)
        {
            var action = await _info_ActionBll.GetEntities(u => u.Id == _info_Action.Id).FirstOrDefaultAsync();
            action.action_name = _info_Action.action_name;
            action.router = _info_Action.router;
            action.icon = _info_Action.icon;
            var flag = _info_ActionBll.Update(action);
            return Content(JsonHelper.JsonToString(null, flag: flag));
        }
        [HttpPost]//多权限逻辑删除
        public async Task<IActionResult> DelAllAction(List<int> Ids)
        {
            return Content(JsonHelper.JsonToString(null, flag: await _info_ActionBll.DelALLByUpdateList(Ids)));
        }
    }
}
