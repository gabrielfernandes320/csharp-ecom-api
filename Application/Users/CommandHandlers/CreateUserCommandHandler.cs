using AutoMapper;
using Domain.Users.Commands;
using Domain.Users.Dtos;
using Domain.Users.Entities;
using Domain.Users.Repositories;
using MediatR;

namespace Application.Users.CommandHandlers;

public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, CreateUserResponseDto>
{
    private readonly IUsersRepository _userRepository;
    private readonly IMapper _mapper;

    public CreateUserCommandHandler(IUsersRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }


    public async Task<CreateUserResponseDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var createdUser = await _userRepository.Create(_mapper.Map<User>(request));
        return _mapper.Map<CreateUserResponseDto>(createdUser);
    }
}