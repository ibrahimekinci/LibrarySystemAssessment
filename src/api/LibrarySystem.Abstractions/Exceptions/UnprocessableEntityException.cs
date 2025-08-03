namespace LibrarySystem.Abstractions.Exceptions
{
    public class UnprocessableEntityException : CustomException
    {
        private const string DEFAULT_MESSAGE = "Unprocessable Entity: The server understands the request but cannot process it due to semantic errors in the input. Please review the data provided and try again.";
        public override string GetDefaultMessage()
        {
            return DEFAULT_MESSAGE;
        }
        public UnprocessableEntityException() : base(DEFAULT_MESSAGE) { }
        public UnprocessableEntityException(string message) : base(message) { }
    }
}
