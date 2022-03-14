using Domain.Users.Dtos;
using MediatR;

namespace Domain.Users.Queries;

public record FindUserQuery(Guid Id) : IRequest<FindUserResponseDto>;