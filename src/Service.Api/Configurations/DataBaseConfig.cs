using Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Service.Api.Configurations
{
    public static class DataBaseConfig
    {
        public static void AddDataBaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddDbContext<StoreControlContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnetion")));

            services.AddDbContext<EventStoreSqlContext>(options =>
              options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
