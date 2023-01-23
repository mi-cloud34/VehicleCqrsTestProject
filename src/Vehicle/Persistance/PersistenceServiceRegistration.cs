using Application.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.Contexts;
using Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
                                                               IConfiguration configuration)
        {
            services.AddDbContext<BaseDbContext>(options =>
                                                     options.UseSqlServer(

                                                         configuration.GetConnectionString("VehicleDB")));
                                                       
            services.AddScoped<ICarRepository, CarRepository>();
            services.AddScoped<IBusRepository, BusRepository>();
            services.AddScoped<IBoatRepository, BoatRepository>();

            return services;
        }

    }
}
