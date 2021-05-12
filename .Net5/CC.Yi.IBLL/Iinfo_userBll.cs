using CC.Yi.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CC.Yi.IBLL
{
    public partial interface Iinfo_userBll
    {
        #region
        //通过用户id来获取用户所有的权限（正常权限+特殊权限）
        #endregion
        Task<object> getActionByUserId(int id);

        #region
        //给用户设置角色
        #endregion
        Task<bool> setRole(int userId, List<int> roleIds);

        #region
        //给用户设置特殊权限
        #endregion
        Task<bool> setSpecialAction(int userId, List<int> actionIds);

        #region
        //多用户逻辑删除
        #endregion
        Task<bool> DelALLByUpdateList(List<int> Ids);
    }
}
