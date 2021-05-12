using CC.Yi.DAL;
using CC.Yi.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Yi.DALFactory
{
    public partial class DbSession : IDbSession
    {
        public Iinfo_userDal info_userDal
        {
            get { return StaticDalFactory.Getinfo_userDal(); }
        }

        public Iinfo_roleDal info_roleDal
        {
            get { return StaticDalFactory.Getinfo_roleDal(); }
        }

        public Iinfo_actionDal info_actionDal
        {
            get { return StaticDalFactory.Getinfo_actionDal(); }
        }

    }
}