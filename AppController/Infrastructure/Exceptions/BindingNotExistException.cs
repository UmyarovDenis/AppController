using System;

namespace AppController.Infrastructure.Exceptions
{
    public class BindingNotExistException : Exception
    {
        public BindingNotExistException()
        { }

        public BindingNotExistException(string exceptionMessage)
            : base(exceptionMessage)
        { }

        public BindingNotExistException(string exceptionMessage, Exception innerException)
            : base(exceptionMessage, innerException)
        { }
    }
}
