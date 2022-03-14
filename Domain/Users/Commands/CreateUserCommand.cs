using Domain.Users.Dtos;
using MediatR;

namespace Domain.Users.Commands;

public record CreateUserCommand(string Name, string Email, string Password, string PasswordConfirmation) : IRequest<CreateUserResponseDto>;