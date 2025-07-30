namespace LibrarySystem.Abstractions.Exceptions
{
    public class ValidationException : CustomException
    {
        private const string DEFAULT_MESSAGE = "Validation Error: The provided data does not meet the required format or constraints.";
        public override string GetDefaultMessage()
        {
            return DEFAULT_MESSAGE;
        }
        public ValidationException() : base(DEFAULT_MESSAGE) { }
        public ValidationException(string message) : base(message) { }
    }
}