using Domain.Common.Exceptions;

namespace Domain.Common.Extensions;

public static class ThrowExtensions
{
    public static void IfNull<TException>(this IThrow validat, dynamic? value) where TException : HttpException, new()
    {
        if (value is not null)
        {
            return;
        }

        throw new TException();
    }

    public static void IfTrue<TException>(this IThrow validat, bool value) where TException :
        HttpException, new()
    {
        if (value is false)
        {
            return;
        }

        throw new TException();
    }
}

public class Throw : IThrow
{
    public static IThrow Exception { get; } = new Throw();

    private Throw()
    {
    }
}

public interface IThrow
{
}