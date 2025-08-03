namespace LibrarySystem.Abstractions.Exceptions
{
    public class BadRequestException : CustomException
    {
        private const string DEFAULT_MESSAGE = "Bad Request: The server could not process the request due to invalid or malformed input. Please check the request parameters and try again.";
        public override string GetDefaultMessage()
        {
            return DEFAULT_MESSAGE;
        }
        public BadRequestException() : base(DEFAULT_MESSAGE) { }
        public BadRequestException(string message) : base(message) { }
    }
}

