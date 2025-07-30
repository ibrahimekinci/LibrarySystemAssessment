namespace LibrarySystem.Abstractions.Exceptions
{
    public class UnauthorizedException : CustomException
    {
        private const string DEFAULT_MESSAGE = "Unauthorized: Authentication failed. Please provide valid credentials.";
        public override string GetDefaultMessage()
        {
            return DEFAULT_MESSAGE;
        }
        public UnauthorizedException() : base(DEFAULT_MESSAGE) { }
        public UnauthorizedException(string message) : base(message) { }
    }
}