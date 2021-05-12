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
    public partial class info_roleBll : BaseBll<info_role>, Iinfo_roleBll
    {
        //设置角色拥有哪些权限
        public async Task<bool> setAction(int roleId,List<int> actionIds)
        {
         var role= await DbSession.info_roleDal.GetEntities(u => u.Id == roleId).Include(u => u.Info_Actions).FirstOrDefaultAsync();
            role.Info_Actions.Clear();
            var allActions = DbSession.info_actionDal.GetEntities(u => actionIds.Contains(u.Id));
            foreach (var k in allActions)
            {
                role.Info_Actions.Add(k);
            }
          return  DbSession.SaveChanges()>0;
        }

        public async Task<bool> DelALLByUpdateList(List<int> Ids)
        {
            var users = await DbSession.info_roleDal.GetEntities(u => Ids.Contains(u.Id)).ToListAsync();
            foreach (var user in users)
            {
                user.is_delete = (short)ViewModel.Enum.DelFlagEnum.Deleted;
            }
            return DbSession.SaveChanges() > 0;
        }
    }
}
