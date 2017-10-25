using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using WeChatShop.weixin;

namespace WeChatShop
{
    public class AutofacConfig
    {
        /// <summary>
        /// 注册依赖
        /// </summary>
        public static void RegisterDenpendency()
        {
            //1.创建一个容器配置对象
            var builder =new ContainerBuilder();
            //2.注册当前MVC项目内的所有控制器
            // Assembly.GetExecutingAssembly()就是获取当前运行的程序中的类
            //.PropertiesAutowired() 使用属性的方式   依赖注入
           // builder.RegisterControllers(typeof(MvcApplication).Assembly).PropertiesAutowired();
            builder.RegisterControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            //3.动态加载这其他程序集的代码
            var service = Assembly.Load("WeChatShop.Service");
            var repository = Assembly.Load("WeChatShop.Repository");

            var iService = Assembly.Load("WeChatShop.IService");
            var iRepository = Assembly.Load("WeChatShop.IRepository");

            //4.注册程序及内的所有类型     注册接口的实现方
            //.Where(r=>r.Name.EndsWith("Service"))  过滤（只获取带有Service结尾的程序集）
            builder.RegisterAssemblyTypes(service).Where(r=>r.Name.EndsWith("Service")).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(repository).Where(r => r.Name.EndsWith("Repository")).AsImplementedInterfaces();

            //创建Ioc容器对象
            var container = builder.Build();

            //5.替换掉MVC内置的控制器实例（转移控制器实例化的权限）
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}