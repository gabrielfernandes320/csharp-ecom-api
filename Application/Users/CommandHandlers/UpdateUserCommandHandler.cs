using AutoMapper;
using Domain.Users.Commands;
using Domain.Users.Dtos;
using Domain.Users.Repositories;
using MediatR;

namespace Application.Users.CommandHandlers;

public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UpdateUserResponseDto>
{
    private readonly IUsersRepository _userRepository;
    private readonly IMapper _mapper;

    public UpdateUserCommandHandler(IUsersRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }


    public async Task<UpdateUserResponseDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        var (guid, name, email) = request;
        var user = await _userRepository.FindById(guid);
        user!.Name = name;
        user.Email = email;
        
        var updatedUser = await _userRepository.Update(guid, user);

        return _mapper.Map<UpdateUserResponseDto>(updatedUser);
    }
}