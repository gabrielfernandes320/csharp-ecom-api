using Domain.Users.Entities;
using MediatR;

namespace Domain.Users.Queries;

public record ListUserQuery : IRequest<IEnumerable<User>>;
