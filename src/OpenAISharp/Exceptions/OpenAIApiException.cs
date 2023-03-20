using System.Net;

namespace OpenAISharp.Exceptions
{
    public class OpenAIApiException : Exception
    {
        public HttpStatusCode StatusCode { get; protected set; }
        public string ResponseContent { get; protected set; }

        public OpenAIApiException(HttpStatusCode statusCode, string responseContent)
        {
            StatusCode = statusCode;
            ResponseContent = responseContent;
        }

        public OpenAIApiException(HttpStatusCode statusCode, string responseContent, string message, Exception innerException) : base(message, innerException)
        {
            StatusCode = statusCode;
            ResponseContent = responseContent;
        }
    }
}