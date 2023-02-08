using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PosTerminal.Net.Application.Common.Interfaces;
using PosTerminal.Net.Infrastructure.Identity;
using PosTerminal.Net.Infrastructure.Persistence;
using PosTerminal.Net.Infrastructure.Persistence.Interceptors;
using PosTerminal.Net.Infrastructure.Services;

namespace PosTerminal.Net.Infrastructure;

public static class ConfigureServices
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<AuditableEntitySaveChangesInterceptor>();

        if (configuration.GetValue<bool>("UseInMemoryDatabase"))
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseInMemoryDatabase("PosDatabase"));
        }
        else
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("PosDatabase"),
                    builder => builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)));
        }

        services.AddScoped<ApplicationDbContextInitialiser>();

        services
            .AddDefaultIdentity<ApplicationUser>()
            .AddRoles<IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>();

        services.AddIdentityServer()
            .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

        services.AddTransient<IDateTime, DateTimeService>();
        services.AddTransient<IIdentityService, IdentityService>();

        services.AddAuthentication()
            .AddIdentityServerJwt();

        services.AddAuthorization(options =>
            options.AddPolicy("CanPurge", policy => policy.RequireRole("Administrator")));

        return services;
    }
}
