namespace LibrarySystem.Abstractions.Exceptions
{
    public class ResourceAlreadyExistsException : CustomException
    {
        private const string DEFAULT_MESSAGE = "Resource Already Exists: The specified resource already exists.";
        public override string GetDefaultMessage()
        {
            return DEFAULT_MESSAGE;
        }
        public ResourceAlreadyExistsException() : base(DEFAULT_MESSAGE) { }
        public ResourceAlreadyExistsException(string message) : base(message) { }
    }
}