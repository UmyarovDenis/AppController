using System;

namespace AppController.Infrastructure.Exceptions
{
    public class ServiceNotExistException : Exception
    {
        public ServiceNotExistException()
        { }

        public ServiceNotExistException(string exceptionMessage)
            : base(exceptionMessage)
        { }

        public ServiceNotExistException(string exceptionMessage, Exception innerException)
            : base(exceptionMessage, innerException)
        { }
    }
}
