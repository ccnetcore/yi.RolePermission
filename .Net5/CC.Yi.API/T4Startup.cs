using Autofac;
using Autofac.Extras.DynamicProxy;
using CC.Yi.BLL;
using CC.Yi.Common.Castle;
using CC.Yi.DAL;
using CC.Yi.IBLL;
using CC.Yi.IDAL;
using System;


namespace CC.Yi.API
{
    public partial class Startup
    {
        //动态 面向AOP思想的依赖注入 Autofac
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterType(typeof(CustomAutofacAop));
            builder.RegisterGeneric(typeof(BaseDal<>)).As(typeof(IBaseDal<>));
            builder.RegisterType<info_userBll>().As<Iinfo_userBll>().EnableInterfaceInterceptors();//表示注入前后要执行Castle，AOP
            builder.RegisterType<info_roleBll>().As<Iinfo_roleBll>().EnableInterfaceInterceptors();//表示注入前后要执行Castle，AOP
            builder.RegisterType<info_actionBll>().As<Iinfo_actionBll>().EnableInterfaceInterceptors();//表示注入前后要执行Castle，AOP
        }
    }
}