using Domain.Common.Interfaces;
using Domain.Users.Entities;

namespace Domain.Users.Repositories;

public interface IUsersRepository : IBaseRepository<User>
{
}