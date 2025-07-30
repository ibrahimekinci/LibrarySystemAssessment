namespace LibrarySystem.Abstractions.Exceptions
{
    public class MethodNotAllowedException : CustomException
    {
        private const string DEFAULT_MESSAGE = "Method Not Allowed: The requested HTTP method is not supported for this resource";
        public override string GetDefaultMessage()
        {
            return DEFAULT_MESSAGE;
        }
        public MethodNotAllowedException() : base(DEFAULT_MESSAGE) { }
        public MethodNotAllowedException(string message) : base(message) { }
    }
}