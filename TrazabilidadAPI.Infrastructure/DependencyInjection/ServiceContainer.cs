using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TrazabilidadAPI.Application.Interfaces;
using TrazabilidadAPI.Infrastructure.Data;
using TrazabilidadAPI.Infrastructure.Repositories;
using TrazabilidadAPI.SharedLibraries.DependencyInjection;

namespace TrazabilidadAPI.Infrastructure.DependencyInjection
{
    public static class ServiceContainer
    {
        public static IServiceCollection AddInfrastructureService(this IServiceCollection services, IConfiguration config)
        {
            //Estas son las configuraciones del DBContext 
            //Tambien se añade la Authenticación JWT
            //Para realizar la migracion debemos tener añadida el servicio de Infrastructure en el proyecto de inicio
            SharedServiceContainer.AddSharedSevices<ApplicationDbContext>(services, config, config["MySerilog:FileNames"]!);


            //Por cada peticion que se haga a la Api se creara una nueva instancia del repositorio
            services.AddScoped<IProcedureRepository, ProcedureRepository>();
            services.AddScoped<IDataSetRepository, DataSetRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }
    }
}
