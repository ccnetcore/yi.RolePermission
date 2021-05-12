using CC.Yi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CC.Yi.IBLL
{
    public partial interface Iinfo_actionBll
    {
        #region
        //多角色逻辑删除
        #endregion
        Task<bool> DelALLByUpdateList(List<int> Ids);

    }
}
