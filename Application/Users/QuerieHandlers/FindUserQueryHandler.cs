using AutoMapper;
using Domain.Common.Exceptions;
using Domain.Common.Extensions;
using Domain.Users.Dtos;
using Domain.Users.Entities;
using Domain.Users.Exceptions;
using Domain.Users.Queries;
using Domain.Users.Repositories;
using MediatR;

namespace Application.Users.QuerieHandlers;

public class FindUserQueryHandler : IRequestHandler<FindUserQuery, FindUserResponseDto>
{
    private readonly IUsersRepository _userRepository;
    private readonly IMapper _mapper;

    public FindUserQueryHandler(IUsersRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<FindUserResponseDto> Handle(FindUserQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.FindById(request.Id);

        Throw.Exception.IfNull<UserNotFoundException>(user);
       
        return _mapper.Map<FindUserResponseDto>(user);
    }
}