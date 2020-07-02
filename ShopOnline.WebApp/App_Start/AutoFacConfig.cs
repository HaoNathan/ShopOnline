using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace ShopOnline.WebApp
{
    public class AutoFacConfig
    {
        public static void Register()
        {
            //配置autofac的基本信息
            //(1) 创建容器
            var builder = new ContainerBuilder();
            //(2) 进行依赖注入的注册
           
            //这个地方我们通过反射来实现直接配置 程序集,写一个语句 实现配置所有的内容
            Assembly dal = Assembly.Load("ShopOnline.Dal"); //通过反射找到对应的dal成功
            builder.RegisterAssemblyTypes(dal).AsImplementedInterfaces(); //通过容器注册反射等得到类型,并且与接口层进行关联

            Assembly bll = Assembly.Load("ShopOnline.Bll");
            builder.RegisterAssemblyTypes(bll).AsImplementedInterfaces();

            //(3) 注册控制器
            builder.RegisterControllers(typeof(AutoFacConfig).Assembly);
            //(4) 构建
            var container = builder.Build();
            //(5) 实现
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}