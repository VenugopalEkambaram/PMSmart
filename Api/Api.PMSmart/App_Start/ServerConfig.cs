using Autofac;
using Autofac.Integration.WebApi;
using Newtonsoft.Json.Serialization;
using System.Web.Http;
using System.Web.Mvc;
using Api.PMSmart.Filters;
using Api.PMSmart.Models;
using Api.PMSmart.Models.DTOS;
using AutoMapper;

namespace Api.PMSmart
{
    internal static class ServerConfig
    {
        internal static void Configure(HttpConfiguration config)
        {
            var formatters = config.Formatters;
            var jsonFormatter = formatters.JsonFormatter;
            var settings = jsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            WebApiConfig.Register(config);
            GlobalConfiguration.Configuration.Filters.Add(new GlobalExceptionFilter());
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterDependencies();
            RegisterAutoMap();
        }

        private static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new ApiModule());
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(builder.Build());
        }

        private static void RegisterAutoMap()
        {
            Mapper.CreateMap<Project, ProjectItem>().ForMember(m => m.Contacts, options => options.Ignore());
            Mapper.CreateMap<ProjectItem, Project>();
            Mapper.CreateMap<Contact, ContactItem>().ForMember(m => m.ProjectId, options => options.Ignore());
            Mapper.CreateMap<ContactItem, Contact>();
        }
    }
}