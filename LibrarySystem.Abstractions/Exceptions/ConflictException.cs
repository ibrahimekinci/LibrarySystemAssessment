namespace LibrarySystem.Abstractions.Exceptions
{
    public class ConflictException : CustomException
    {
        private const string DEFAULT_MESSAGE = "Conflict: The request could not be processed due to a conflict with the current state of the resource. Please verify the resource status and try again.";
        public override string GetDefaultMessage()
        {
            return DEFAULT_MESSAGE;
        }
        public ConflictException() : base(DEFAULT_MESSAGE) { }
        public ConflictException(string message) : base(message) { }
    }
}
