using LibrarySystem.DAL.Helpers;

namespace LibrarySystem.Tests.Integration
{
    public abstract class BaseTest
    {
        public BaseTest()
        {
            ConnectionResolver.ConnectionString = "Data Source=localhost;Initial Catalog=LibrarySystem;User ID=sa;Password=Str0ng!Passw0rd123;TrustServerCertificate=True";
        }
    }
}
