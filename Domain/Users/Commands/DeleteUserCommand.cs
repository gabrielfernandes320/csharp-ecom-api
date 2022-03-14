using MediatR;

namespace Domain.Users.Commands;

public record DeleteUserCommand(Guid Id) : IRequest;