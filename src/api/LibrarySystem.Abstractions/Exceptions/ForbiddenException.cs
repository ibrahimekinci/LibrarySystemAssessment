namespace LibrarySystem.Abstractions.Exceptions
{
    public class ForbiddenException : CustomException
    {
        private const string DEFAULT_MESSAGE = "Forbidden: You do not have permission to access this resource.";
        public override string GetDefaultMessage()
        {
            return DEFAULT_MESSAGE;
        }
        public ForbiddenException() : base(DEFAULT_MESSAGE) { }
        public ForbiddenException(string message) : base(message) { }
    }
}