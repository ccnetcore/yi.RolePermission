using CC.Yi.DAL;
using CC.Yi.IDAL;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CC.Yi.DALFactory
{
    public partial class StaticDalFactory
    {
        public static Iinfo_userDal Getinfo_userDal()
        {
            Iinfo_userDal Data = CallContext.GetData("info_userDal") as Iinfo_userDal;
            if (Data == null)
            {
                Data = new info_userDal();
                CallContext.SetData("info_userDal", Data);
            }
            return Data;
        }

        public static Iinfo_roleDal Getinfo_roleDal()
        {
            Iinfo_roleDal Data = CallContext.GetData("info_roleDal") as Iinfo_roleDal;
            if (Data == null)
            {
                Data = new info_roleDal();
                CallContext.SetData("info_roleDal", Data);
            }
            return Data;
        }

        public static Iinfo_actionDal Getinfo_actionDal()
        {
            Iinfo_actionDal Data = CallContext.GetData("info_actionDal") as Iinfo_actionDal;
            if (Data == null)
            {
                Data = new info_actionDal();
                CallContext.SetData("info_actionDal", Data);
            }
            return Data;
        }

    }
}