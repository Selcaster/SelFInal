using Microsoft.AspNetCore.Http;

namespace Musico.BL.Exceptions.BlogExceptions;
public class AlreadyReactedException : Exception, IBaseException
{
    public int Code => StatusCodes.Status400BadRequest;

    public string ErrorMessage { get; }
    public AlreadyReactedException()
    {
        ErrorMessage = "You already liked this song";
    }

    public AlreadyReactedException(string message) : base(message)
    {
        ErrorMessage = message;
    }
}
