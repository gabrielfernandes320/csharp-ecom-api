using Domain.Common.Exceptions;

namespace Domain.Users.Exceptions;

public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException() : base(parameter: "Id", msg: "User Not Found")
    {
    }
}