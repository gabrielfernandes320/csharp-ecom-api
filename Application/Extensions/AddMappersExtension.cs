using Domain.Users.Mappers;

namespace Application.Extensions;

public static class AddMappersExtension
{
    public static void AddMappers(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(UserMapper));
    }
}