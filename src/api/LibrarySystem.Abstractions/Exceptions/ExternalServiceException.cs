namespace LibrarySystem.Abstractions.Exceptions
{
    public class ExternalServiceException : CustomException
    {
        private const string DEFAULT_MESSAGE = "";
        public override string GetDefaultMessage()
        {
            return DEFAULT_MESSAGE;
        }
        public ExternalServiceException() : base(DEFAULT_MESSAGE) { }
        public ExternalServiceException(string message) : base(message) { }
    }
}