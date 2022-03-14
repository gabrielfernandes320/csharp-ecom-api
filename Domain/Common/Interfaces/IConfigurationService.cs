namespace Domain.Common.Interfaces;

public interface IConfigurationService
{
    public string? ConnectionString { get; init; }
}