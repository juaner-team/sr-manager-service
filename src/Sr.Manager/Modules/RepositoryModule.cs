using Autofac;
using System.Reflection;

namespace Sr.Manager.Modules
{
    public class RepositoryModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            Assembly assemblyRepository = Assembly.Load("Sr.Manager.Infrastructure");
            builder.RegisterAssemblyTypes(assemblyRepository)
                    .Where(a => a.Name.EndsWith("Repo"))
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();
        }
    }
}
