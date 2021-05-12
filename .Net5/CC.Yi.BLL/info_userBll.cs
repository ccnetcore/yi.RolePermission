using CC.Yi.IBLL;
using CC.Yi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CC.Yi.BLL
{
    public partial class info_userBll : BaseBll<info_user>, Iinfo_userBll
    {
        short delFlagNormal = (short)ViewModel.Enum.DelFlagEnum.Normal;
        short delFlagDeleted = (short)ViewModel.Enum.DelFlagEnum.Deleted;
        //得到用户所具有的全部权限：正常权限+特殊权限
        public async  Task<object> getActionByUserId(int id)
        {
            //这里是通过角色来得到的权限
            var user = await DbSession.info_userDal.GetEntities(u => u.Id == id).Include(u => u.Info_Actions).Include(u => u.Info_Roles).ThenInclude(u => u.Info_Actions).FirstOrDefaultAsync();
            //获取所有去除逻辑删除的角色
            var allRoles = (from r in user.Info_Roles
                            where r.is_delete == delFlagNormal
                            select r).ToList();

            //通过有效角色获取所有去除逻辑删除的权限
            var allAction = (from r in allRoles
                             from a in r.Info_Actions
                             where a.is_delete== delFlagNormal
                             select a).ToList();
            //这里是获取有效的特殊权限
            var specialAction =(from r in user.Info_Actions
                                where r.is_delete== delFlagNormal
                                select r).ToList();

            //合并两个权限
            allAction.AddRange(specialAction.AsEnumerable());

            //去重
            var myAllAction = allAction.Distinct().ToList().Select(u => new { u.Id, u.action_name,u.router,u.icon });

            return myAllAction;
        }

        //设置用户拥有哪些角色
        public async Task<bool> setRole(int userId,List<int> roleIds)
        {
         var user= await DbSession.info_userDal.GetEntities(u => u.Id == userId).Include(u => u.Info_Roles).FirstOrDefaultAsync();
            user.Info_Roles.Clear();
            var allRoles = DbSession.info_roleDal.GetEntities(u => roleIds.Contains(u.Id));
            foreach (var k in allRoles)
            {
                user.Info_Roles.Add(k);
            }
          return  DbSession.SaveChanges()>0;
        }


        //设置用户特殊权限
        public async Task<bool> setSpecialAction(int userId, List<int> actionIds)
        {
            var user = await DbSession.info_userDal.GetEntities(u => u.Id == userId).Include(u => u.Info_Actions).FirstOrDefaultAsync();
            user.Info_Actions.Clear();
            var allActions = DbSession.info_actionDal.GetEntities(u => actionIds.Contains(u.Id));
            foreach (var k in allActions)
            {
                user.Info_Actions.Add(k);
            }
            return DbSession.SaveChanges() > 0;
        }

        public async Task<bool> DelALLByUpdateList(List<int> Ids)
        {
          var users= await  DbSession.info_userDal.GetEntities(u => Ids.Contains(u.Id)).ToListAsync();
            foreach (var user in users)
            {
                user.is_delete = delFlagDeleted;
            }
           return DbSession.SaveChanges() > 0;
        }
    
    }
}
