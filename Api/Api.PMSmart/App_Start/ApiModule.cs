using Api.PMSmart.Services;
using Autofac;
using Autofac.Integration.WebApi;
using Api.PMSmart.Repositories;

namespace Api.PMSmart
{
    public class ApiModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(GetType().Assembly);

            builder.RegisterType<ProjectService>().AsImplementedInterfaces();
            builder.RegisterType<ProjectRepository>().AsImplementedInterfaces();
            builder.RegisterType<ContactService>().AsImplementedInterfaces();
            builder.RegisterType<ContactRepository>().AsImplementedInterfaces();
        }
    }
}