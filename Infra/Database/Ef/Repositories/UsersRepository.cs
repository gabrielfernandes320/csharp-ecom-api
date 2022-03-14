using Domain.Users.Entities;
using Domain.Users.Repositories;

namespace Infra.Database.Ef.Repositories;

public class UsersRepository : BaseRepository<User>, IUsersRepository
{
    public UsersRepository(Context context) : base(context)
    {
        
    }
}