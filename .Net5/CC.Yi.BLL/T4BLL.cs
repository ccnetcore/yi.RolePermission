
using CC.Yi.IBLL;
using CC.Yi.IDAL;
using CC.Yi.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Yi.BLL
{
    public partial class info_userBll : BaseBll<info_user>, Iinfo_userBll
        {
            public info_userBll(IBaseDal<info_user> cd):base(cd)
            {
                CurrentDal = cd;
            }
        }
    public partial class info_roleBll : BaseBll<info_role>, Iinfo_roleBll
        {
            public info_roleBll(IBaseDal<info_role> cd):base(cd)
            {
                CurrentDal = cd;
            }
        }
    public partial class info_actionBll : BaseBll<info_action>, Iinfo_actionBll
        {
            public info_actionBll(IBaseDal<info_action> cd):base(cd)
            {
                CurrentDal = cd;
            }
        }
}