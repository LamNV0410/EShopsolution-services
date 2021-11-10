using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace EshopSolution.Extensions.Exceptions
{
    public class HttpStatusException : Exception
    {
        public HttpStatusException()
        {

        }
        public HttpStatusException(string message) : base(message)
        {

        }
        public HttpStatusException(HttpStatusCode status, string errorMessage, string errorCode) : base(errorMessage)
        {
            Status = status;
            ErrorCode = errorCode;
        }

        public HttpStatusCode Status { get; }
        public string ErrorCode { get; }
    }
}
