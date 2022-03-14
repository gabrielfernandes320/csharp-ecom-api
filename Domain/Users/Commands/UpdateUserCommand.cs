using Domain.Users.Dtos;
using MediatR;

namespace Domain.Users.Commands;

public record UpdateUserCommand(Guid Id, string Name, string Email) : IRequest<UpdateUserResponseDto>;