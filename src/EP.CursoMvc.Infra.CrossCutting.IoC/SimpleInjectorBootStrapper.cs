using EP.CursoMvc.Application.Interfaces;
using EP.CursoMvc.Application.Services;
using EP.CursoMvc.Domain.Interfaces.Repository;
using EP.CursoMvc.Domain.Interfaces.Services;
using EP.CursoMvc.Domain.Services;
using EP.CursoMvc.Infra.Data.Context;
using EP.CursoMvc.Infra.Data.Interfaces;
using EP.CursoMvc.Infra.Data.Repositoty;
using EP.CursoMvc.Infra.Data.UoW;
using SimpleInjector;

namespace EP.CursoMvc.Infra.CrossCutting.IoC
{
    public class SimpleInjectorBootStrapper
    {

        public static void Register(Container container)
        {


            

            //APP
            container.Register<IClienteAppService, ClienteAppService>(Lifestyle.Scoped);


            //Domain
            container.Register<IClienteService, ClienteService>(Lifestyle.Scoped);


            //Data
            container.Register<IClienteRepository, ClienteRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<CursoMvcContext>(Lifestyle.Scoped);

        }
    }
}
