using System.Reflection;
using Autofac;

namespace Fahim.Chat.UI.DependencyProvider
{
    public class AutofacModule : Autofac.Module
    {
        private readonly string _connectionString;

        public AutofacModule(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void Load(ContainerBuilder builder)
        {
            var asm = Assembly.Load(new AssemblyName() { Name = "Fahim.Chat.UpdateDatabase" });
            builder.RegisterAssemblyTypes(asm).WithParameter("connectionString", _connectionString)
                .Where(x => x.ToString().EndsWith("Repository"))
                .AsImplementedInterfaces();
        }
    }
}