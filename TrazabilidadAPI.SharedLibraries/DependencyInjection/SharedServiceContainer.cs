using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace TrazabilidadAPI.SharedLibraries.DependencyInjection
{
    public static class SharedServiceContainer
    {
        public static IServiceCollection AddSharedSevices<TContext>(this IServiceCollection services, IConfiguration config, String fileName) where TContext : DbContext
        {
            //Configuraciones para la base de datos, estas tienen que estar inyectadas en el programa de inicio para empezar la migracion
            services.AddDbContext<TContext>(
                option => option.UseSqlServer
                    (
                        config.GetConnectionString("TrazabilidadConnection"),
                        sqlserverOption => sqlserverOption.EnableRetryOnFailure()
                    )

                );

            //Agregamos la Authenticacion 
            JWTAuthenticationscheme.AddJWTAuthenticationScheme(services, config);
            return services;
            
        }

    }
}
