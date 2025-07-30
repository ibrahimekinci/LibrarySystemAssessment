namespace LibrarySystem.Abstractions.Exceptions
{
    public interface ICustomException
    {
        string GetDefaultMessage();
        string GetMessage();
        string GetUserFriendlyMessage();
        bool ShouldLog();
    }
}
