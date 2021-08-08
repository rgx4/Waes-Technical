using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WaesTechnical.Application.UseCases;
using WaesTechnical.Application.UseCases.Interfaces;
using WaesTechnical.Domain.Interfaces;
using WaesTechnical.Domain.Services;
using WaesTechnical.Infrastructure.Interfaces;
using WaesTechnical.Infrastructure.Repositories;
using WaesTechnical.Validators;

namespace WaesTechnical.Infrastructure.IoC.Extensions
{
    public static class RegisterServices
    {
        public static void Register(IServiceCollection services)
        {
            //Application
            services.AddScoped<IDiffUseCases, DiffUseCases>();

            //Domain
            services.AddScoped<IDiffService, DiffService>();
            services.AddScoped<IDataValidator, DataValidator>();
            services.AddScoped<IDiffCount, DiffCount>();

            //Infra
            services.AddScoped<IDataRepository, DataRepository>();
        }   
    }
}
