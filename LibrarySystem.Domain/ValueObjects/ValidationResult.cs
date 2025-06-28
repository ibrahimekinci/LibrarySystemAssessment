namespace LibrarySystem.Domain.ValueObjects
{
    public class ValidationResult
    {
        public bool IsValid { get; }
        public string Message { get; }

        private ValidationResult(bool isValid, string message)
        {
            IsValid = isValid;
            Message = message;
        }

        public static ValidationResult Success() => new ValidationResult(true, "Valid.");
        public static ValidationResult Failure(string message) => new ValidationResult(false, message);
    }
}
