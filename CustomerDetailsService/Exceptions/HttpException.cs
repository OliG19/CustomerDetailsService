using System;

namespace CustomerDetailsService.Exceptions
{
    public class HttpException : Exception
    {
        private readonly int _httpStatusCode;

        public int StatusCode => _httpStatusCode;

        protected HttpException(int httpStatusCode, string message) : base(message)
        {
            _httpStatusCode = httpStatusCode;
        }

    }
}
