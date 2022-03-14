using AutoMapper;
using Domain.Users.Commands;
using Domain.Users.Dtos;
using Domain.Users.Entities;

namespace Domain.Users.Mappers;

public class UserMapper : Profile
{
    public UserMapper()
    {
        CreateMap<CreateUserCommand, User>();
        CreateMap<User, CreateUserResponseDto>();
        CreateMap<User, FindUserResponseDto>();
        CreateMap<UpdateUserCommand, User>();
        CreateMap<User, UpdateUserResponseDto>();
    }
}