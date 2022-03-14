using Application.Users.CommandHandlers;
using MediatR;

namespace Application.Extensions;

public static class AddCommandsExtension
{
    public static void AddCommands(this IServiceCollection services)
    {
        services.AddMediatR(typeof(CreateUserCommandHandler).Assembly);
        services.AddMediatR(typeof(DeleteUserCommandHandler).Assembly);
        services.AddMediatR(typeof(UpdateUserCommandHandler).Assembly);
    }
}