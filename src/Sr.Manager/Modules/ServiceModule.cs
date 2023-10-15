using Autofac;
using Autofac.Extras.DynamicProxy;
using Sr.Manager.Core.AOP.Intercepts;
using Sr.Manager.Service.Core.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Sr.Manager.Modules
{
    public class ServiceModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWorkAsyncInterceptor>();
            builder.RegisterType<UnitOfWorkInterceptor>();

            builder.RegisterType<CacheIntercept>();

            List<Type> interceptorServiceTypes = new List<Type>()
            {
                typeof(UnitOfWorkInterceptor),
                typeof(CacheIntercept),
            };

            string[] notIncludes = new string[]
            {
                nameof(IdentityServer4Service),
                nameof(JwtTokenService),
            };

            Assembly servicesDllFile = Assembly.Load("Sr.Manager.Service");
            builder.RegisterAssemblyTypes(servicesDllFile)
                .Where(a => a.Name.EndsWith("Service") && notIncludes.All(r => r != a.Name) && !a.IsAbstract && !a.IsInterface && a.IsPublic)
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope()
                .PropertiesAutowired()// 属性注入
                .InterceptedBy(interceptorServiceTypes.ToArray())
                .EnableInterfaceInterceptors();

            //使用名称进行实现注册
            builder.RegisterType<IdentityServer4Service>().Named<ITokenService>(nameof(IdentityServer4Service)).InstancePerLifetimeScope();
            builder.RegisterType<JwtTokenService>().Named<ITokenService>(nameof(JwtTokenService)).InstancePerLifetimeScope();
        }
    }
}
