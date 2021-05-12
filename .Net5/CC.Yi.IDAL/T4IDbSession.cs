using CC.Yi.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CC.Yi.IDAL
{
    public partial interface IDbSession
    {
        Iinfo_userDal info_userDal{get;}

        Iinfo_roleDal info_roleDal{get;}

        Iinfo_actionDal info_actionDal{get;}

    }
}