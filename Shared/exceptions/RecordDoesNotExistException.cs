using System;

namespace Shared.exceptions
{
    public class RecordDoesNotExistException : Exception
    {
        public RecordDoesNotExistException() {}

        public RecordDoesNotExistException(string message)
                : base(message) {}

        public RecordDoesNotExistException(string message, Exception innerException) 
                : base(message, innerException)
        {}
    }
}
