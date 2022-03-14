using Domain.Common.Interfaces;

namespace Infra.Configurations;

public class ConfigurationService : IConfigurationService
{
    public string? ConnectionString { get; init; }

    public ConfigurationService(IConfiguration configuration)
    {
        ConnectionString = configuration.GetConnectionString("DefaultConnection") ?? null;
    }
}