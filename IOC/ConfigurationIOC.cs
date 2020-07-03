using Adapter.Interfaces;
using Adapter.Mapper;
using Application.Interfaces;
using Application.Services;
using Autofac;
using Core.Repositories;
using Core.Services;
using Repository.Repositories;
using Services;

namespace IOC
{
    public class ConfigurationIOC
    {
        public static void Load(ContainerBuilder builder)
        {
            #region IOC Application
            builder.RegisterType<ApplicationServiceUser>().As<IApplicationServiceUser>();
            #endregion

            #region IOC Services
            builder.RegisterType<ServiceUser>().As<IServiceUser>();
            #endregion

            #region IOC Repositorys SQL
            builder.RegisterType<RepositoryUser>().As<IRepositoryUser>();
            #endregion

            #region IOC Mapper
            builder.RegisterType<MapperUser>().As<IMapperUser>();
            #endregion
        }
    }
}
