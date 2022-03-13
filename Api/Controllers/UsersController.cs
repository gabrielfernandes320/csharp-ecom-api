using System.Net;
using Domain.Common.Exceptions;
using Domain.Users.Entities;
using Infra.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase, IController<User>
{
    [HttpGet]
    public Task<ICollection<User>> GetAsync()
    {
        throw new NotFoundException("nao achou!!!", parameter: "id");
    }

    [HttpGet("{id:guid}")]
    public Task<User> GetAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public Task<User> PostAsync([FromBody] User user)
    {
        throw new NotImplementedException();
    }

    [HttpPatch("{id:guid}")]
    public Task<User> PutAsync(Guid id, [FromBody] User user)
    {
        throw new NotImplementedException();
    }

    [HttpDelete("{id:guid}")]
    public Task DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }
}