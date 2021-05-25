using Infra.CrossCutting.Identity.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;


namespace Infra.CrossCutting.Identity
{
    public static class Abstractions
    {
        public static IdentityBuilder AddIdentityConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentException(nameof(services));

            return services.AddDefaultIdentity<IdentityUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<IdentityAppDbContext>()
                .AddDefaultTokenProviders();
        }

        public static IdentityBuilder AddDefaultIdentity(this IServiceCollection services, Action<IdentityOptions> options = null)
        {
            if (services == null) throw new ArgumentException(nameof(services));

            return services.AddDefaultIdentity<IdentityUser>(options);
        }

        public static IdentityBuilder AddCustomIdentity<TIdentityUser>(this IServiceCollection services, Action<IdentityOptions> options = null)
            where TIdentityUser : IdentityUser
        {
            if (services == null) throw new ArgumentException(nameof(services));

            return services.AddDefaultIdentity<TIdentityUser>(options);
        }

        public static IdentityBuilder AddCustomIdentity<TIdentityUser, TKey>(this IServiceCollection services, Action<IdentityOptions> options = null)
            where TIdentityUser : IdentityUser
            where TKey : IEquatable<TKey>
        {
            if (services == null) throw new ArgumentException(nameof(services));

            return services.AddDefaultIdentity<TIdentityUser>(options);
        }

        public static IdentityBuilder AddCustomRoles(this IdentityBuilder builder)
        {
            return builder.AddRoles<IdentityRole>();
        }

        public static IdentityBuilder AddCustomRole<TRole>(this IdentityBuilder builder)
            where TRole : IdentityRole
        {
            return builder.AddRoles<TRole>();
        }

        public static IdentityBuilder AddCustomRole<TRole, TKey>(this IdentityBuilder builder)
            where TRole : IdentityRole
            where TKey : IEquatable<TKey>
        {
            return builder.AddRoles<TRole>();
        }

        public static IdentityBuilder AddCustomEntityFrameworkStores(this IdentityBuilder builder)
        {
            return builder.AddEntityFrameworkStores<IdentityAppDbContext>();
        }

        public static IdentityBuilder AddCustomEntityFrameworkStores<TContext>(this IdentityBuilder builder)
            where TContext : DbContext
        {
            return builder.AddEntityFrameworkStores<TContext>();
        }

        public static IServiceCollection AddEntityFrameworkContextConfigurations(this IServiceCollection services, Action<DbContextOptionsBuilder> options)
        {
            if (services == null) throw new ArgumentException(nameof(services));
            if (options == null) throw new ArgumentException(nameof(options));

            return services.AddDbContext<IdentityAppDbContext>(options);
        }

        public static IApplicationBuilder UserAuthConfiguration(this ApplicationBuilder app)
        {
            if (app == null) throw new ArgumentException(nameof(app));

            return app.UseAuthentication()
                     .UseAuthentication();
        }
    }
}
