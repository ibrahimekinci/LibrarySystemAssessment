namespace LibrarySystem.Tests.Integration.WebApi
{
    public class BaseWebApiTest : BaseTest
    {
        public static string BaseUrl { get; private set; } = "http://localhost:5000";
    }
}
