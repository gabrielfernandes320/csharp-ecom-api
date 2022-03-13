using System.Net;

namespace Domain.Common.Exceptions;

public class NotFoundException : HttpException
{
    public NotFoundException(string msg = "Entity not Found", string code = "NOT_FOUND", string? parameter = default,
        HttpStatusCode status = HttpStatusCode
            .NotFound) : base(msg, code, status, parameter)
    {
    }
}

public class InvalidArgumentException : HttpException
{
    public InvalidArgumentException(string msg = "Invalid Argument", string code = "INVALID_ARGUMENT", string? parameter = default,
        HttpStatusCode status = HttpStatusCode
            .BadRequest) : base(msg, code, status, parameter)
    {
    }
}