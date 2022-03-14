using Domain.Users.Entities;
using Domain.Users.Queries;
using Domain.Users.Repositories;
using MediatR;

namespace Application.Users.QuerieHandlers;

public class ListUsersQueryHandler : IRequestHandler<ListUserQuery, IEnumerable<User>>
{
    private readonly IUsersRepository _userRepository;

    public ListUsersQueryHandler(IUsersRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<IEnumerable<User>> Handle(ListUserQuery request, CancellationToken cancellationToken)
    {
        return await _userRepository.FindAll();
    }
}