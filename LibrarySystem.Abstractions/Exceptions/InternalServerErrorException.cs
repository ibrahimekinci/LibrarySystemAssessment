namespace LibrarySystem.Abstractions.Exceptions
{
    public class InternalServerErrorException : CustomException
    {
        private const string DEFAULT_MESSAGE = "Internal Server Error: An unexpected error occurred. Please try again later.";
        public override string GetDefaultMessage()
        {
            return DEFAULT_MESSAGE;
        }
        public InternalServerErrorException() : base(DEFAULT_MESSAGE) { }
        public InternalServerErrorException(string message) : base(message) { }
    }
}