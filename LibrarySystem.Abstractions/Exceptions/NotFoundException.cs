namespace LibrarySystem.Abstractions.Exceptions
{
    public class NotFoundException : CustomException
    {
        private const string DEFAULT_MESSAGE = "Not Found: The requested resource could not be found on the server. Please verify the resource identifier and try again.";
        public override string GetDefaultMessage()
        {
            return DEFAULT_MESSAGE;
        }
        public NotFoundException() : base(DEFAULT_MESSAGE) { }
        public NotFoundException(string message) : base(message) { }
    }
}
