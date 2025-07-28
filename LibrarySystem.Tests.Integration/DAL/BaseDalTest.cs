using LibrarySystem.DAL.Helpers;

namespace LibrarySystem.Tests.Integration.DAL
{
    public abstract class BaseDalTest
    {
        public BaseDalTest()
        {
            ConnectionResolver.ConnectionString = "Data Source=localhost;Initial Catalog=LibrarySystem;User ID=sa;Password=Str0ng!Passw0rd123;TrustServerCertificate=True";
        }
    }
}
