using System.Net;

namespace Domain.Common.Exceptions
{
    public class HttpException : Exception
    {
        public string Code { get; }
        public string? Parameter { get; }
        public HttpStatusCode StatusCode { get;}

        protected HttpException(string message, string code, HttpStatusCode statusCode, string? parameter) : base(message)
        {
            Code = code;
            StatusCode = statusCode;
            Parameter = parameter;
        }

       
    }
}
