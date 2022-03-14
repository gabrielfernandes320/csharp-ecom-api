using AutoMapper;
using Domain.Users.Commands;
using Domain.Users.Repositories;
using MediatR;

namespace Application.Users.CommandHandlers;

public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
{
    private readonly IUsersRepository _userRepository;
    private readonly IMapper _mapper;

    public DeleteUserCommandHandler(IUsersRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await _userRepository.Delete(request.Id);
        return Unit.Value;
    }
}