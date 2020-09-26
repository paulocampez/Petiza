using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using Petiza.Catalogo.Application.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Petiza.Catalogo.Api.Configuration
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            AutoMapperConfig.RegisterMappings();
        }
    }
}
