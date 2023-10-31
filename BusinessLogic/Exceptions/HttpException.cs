using System.Net;

namespace BusinessLogic.Exceptions
{
    [Serializable]
    public class HttpException : Exception
    {
        public HttpStatusCode Status { get; set; }

        public HttpException()
        {
            Status = HttpStatusCode.InternalServerError;
        }

        public HttpException(string message, HttpStatusCode status) : base(message)
        {
            Status = status;
        }

        public HttpException(string message, HttpStatusCode status, Exception inner) : base(message, inner)
        {
            Status = status;
        }

        protected HttpException(System.Runtime.Serialization.SerializationInfo info,
                                System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
