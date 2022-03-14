using Domain.Users.Commands;
using Domain.Users.Dtos;
using Domain.Users.Entities;
using Domain.Users.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;

    public UsersController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ICollection<User>> GetAsync()
    {
        return (ICollection<User>) await _mediator.Send(new ListUserQuery());
    }

    [HttpGet("{id:guid}")]
    public async Task<FindUserResponseDto> GetAsync(Guid id)
    {
        return await _mediator.Send(new FindUserQuery(id));
    }

    [HttpPost]
    public async Task<CreateUserResponseDto> PostAsync([FromBody] CreateUserCommand user)
    {
        return await _mediator.Send(user);
    }

    [HttpPatch("{id:guid}")]
    public async Task<UpdateUserResponseDto> PatchAsync(Guid id, [FromBody] UpdateUserCommand user)
    {
        return await _mediator.Send(user with {Id = id});
    }

    [HttpDelete("{id:guid}")]
    public async Task DeleteAsync(Guid id)
    {
        await _mediator.Send(new DeleteUserCommand(id));
    }
}