using Application.Users.QuerieHandlers;
using MediatR;

namespace Application.Extensions;

public static class AddQueriesExtension
{
    public static void AddQueries(this IServiceCollection services)
    {
        services.AddMediatR(typeof(ListUsersQueryHandler).Assembly);
        services.AddMediatR(typeof(FindUserQueryHandler).Assembly);
    }
}