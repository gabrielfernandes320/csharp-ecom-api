using Domain.Common.Interfaces;
using Domain.Users.Repositories;
using Infra.Configurations;
using Infra.Database.Ef;
using Infra.Database.Ef.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infra.Extensions;

public static class AddInfraExtension
{
    public static void AddInfra(this IServiceCollection services)
    {
        services.AddTransient<IUsersRepository, UsersRepository>();
        services.AddSingleton<IConfigurationService, ConfigurationService>();
        services.AddDbContext<Context>(options => options.UseNpgsql("User ID=postgres;Password=admin;Host=localhost;Port=5432;Database=ecomapi;Pooling=true;"));
    }
}