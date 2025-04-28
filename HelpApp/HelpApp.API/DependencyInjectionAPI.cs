﻿using HelpApp.Domain.Interfaces;
using HelpApp.Infra.Data.Context;
using HelpApp.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HelpApp.API
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfraEstructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }
    }
}
