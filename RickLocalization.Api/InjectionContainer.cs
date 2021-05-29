using Microsoft.Extensions.DependencyInjection;
using RickLocalization.Repository.Context;
using RickLocalization.Repository.Repository;
using RickLocalization.Repository.Repository.Interfaces;
using RickLocalization.Service;
using RickLocalization.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RickLocalization.Api
{
    public   class InjectionContainer
    { 
            public static void Setup(IServiceCollection services)
            {
                RegisterServices(services); 
            }

        private static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<IHumansByDimensionsService, HumansByDimensionsService>();
            services.AddScoped<IHumansByDimensionsRepository, HumansByDimensionsRepository>();
        }
         
    }
}
