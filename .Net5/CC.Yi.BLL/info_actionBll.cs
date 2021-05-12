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
    public partial class info_actionBll : BaseBll<info_action>, Iinfo_actionBll
    {
        public async Task<bool> DelALLByUpdateList(List<int> Ids)
        {
            var users = await DbSession.info_actionDal.GetEntities(u => Ids.Contains(u.Id)).ToListAsync();
            foreach (var user in users)
            {
                user.is_delete = (short)ViewModel.Enum.DelFlagEnum.Deleted;
            }
            return DbSession.SaveChanges() > 0;
        }
    }
}
