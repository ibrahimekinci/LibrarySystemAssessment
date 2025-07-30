using System;

namespace LibrarySystem.Abstractions.Exceptions
{
    public class CustomException : Exception, ICustomException
    {
        private const string DEFAULT_MESSAGE = "An error occurred.";
        private readonly string _message;
        public CustomException() : base(DEFAULT_MESSAGE)
        {
            _message = DEFAULT_MESSAGE;
        }
        public CustomException(string message) : base(message)
        {
            _message = message;
        }
        public virtual string GetDefaultMessage()
        {
            return DEFAULT_MESSAGE;
        }
        public virtual string GetMessage()
        {
            return !String.IsNullOrEmpty(_message) ? _message : GetDefaultMessage();
        }

        public virtual string GetUserFriendlyMessage()
        {
            return GetMessage();
        }

        public virtual bool ShouldLog()
        {
            return true;
        }
    }
}
