using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Repositories;
using LibrarySystem.Domain.Enums;
using System.Data;

namespace LibrarySystem.Tests.DAL
{
    public class ReportRepositoryTests : IDisposable
    {
        private readonly ReportRepository _reportRepo = new();
        private readonly UserRepository _userRepo = new();
        private readonly BookRepository _bookRepo = new();
        private readonly BarrowRepository _barrowRepo = new();

        private string _testIsbn;
        private int _testUserId;

        public ReportRepositoryTests()
        {
            SetupTestData();
        }

        private void SetupTestData()
        {

            // Create book
            _testIsbn = "ISBN_" + Guid.NewGuid().ToString("N").Substring(0, 4);
            var book = new BookEntity
            {
                ISBN = _testIsbn,
                BookName = "Report Test Book",
                Author = 1,
                Category = 1,
                Language = 1,
                PublishYear = 2024,
                Pages = 100,
                Publisher = "ReportPub"
            };
            _bookRepo.Add(book);

            // Create user
            var user = new UserEntity
            {
                UserName = "user_" + Guid.NewGuid().ToString("N").Substring(0, 4),
                Password = "pass",
                PhoneNumber = "0400000000",
                Email = "report@test.com",
                UserLevel = UserLevelEnum.Student
            };
            _testUserId = _userRepo.Add(user);

            // Overdue borrow
            _barrowRepo.Add(new BarrowEntity
            {
                UID = _testUserId,
                ISBN = _testIsbn,
                BorrowDate = DateTime.Now.AddDays(-40),
                ReturnDate = DateTime.Now.AddDays(-30)
            });

            // Recent borrows
            _barrowRepo.Add(new BarrowEntity
            {
                UID = _testUserId,
                ISBN = _testIsbn,
                BorrowDate = DateTime.Now.AddDays(-10),
                ReturnDate = DateTime.Now.AddDays(10)
            });

            _barrowRepo.Add(new BarrowEntity
            {
                UID = _testUserId,
                ISBN = _testIsbn,
                BorrowDate = DateTime.Now.AddDays(-5),
                ReturnDate = DateTime.Now.AddDays(5)
            });

            _barrowRepo.Add(new BarrowEntity
            {
                UID = _testUserId,
                ISBN = _testIsbn,
                BorrowDate = DateTime.Now.AddDays(-5),
                ReturnDate = DateTime.Now.AddDays(5)
            });
        }

        [Fact]
        public void GetMostBorrowedBooks_Should_Contain_TestBook()
        {
            var table = _reportRepo.GetMostBorrowedBooks();
            Assert.NotNull(table);
            Assert.True(table.Rows.Count > 0);

            var found = table.AsEnumerable().Any(r => r.Field<string>("ISBN") == _testIsbn);
            Assert.True(found);
        }

        [Fact]
        public void GetOverdueBooks_Should_Contain_TestUser()
        {
            var table = _reportRepo.GetOverdueBooks();
            Assert.NotNull(table);
            Assert.True(table.Rows.Count > 0);

            var found = table.AsEnumerable().Any(r =>
                r.Field<string>("ISBN") == _testIsbn);

            Assert.True(found);
        }

        [Fact]
        public void GetBorrowedBooksByCategory_Should_Include_TestCategory()
        {
            var table = _reportRepo.GetBorrowedBooksByCategory();
            Assert.NotNull(table);
            Assert.True(table.Rows.Count > 0);

            var found = table.AsEnumerable().Any(r =>
                r.Field<int>("CID") == 1);

            Assert.True(found);
        }

        public void Dispose()
        {
            // Cleanup order: borrow → book → user → category → language
            try
            {
                var barrows = _barrowRepo.GetAllByUserId(_testUserId);
                if (barrows != null)
                {
                    foreach (var barrow in barrows.Where(b => b.ISBN == _testIsbn))
                    {
                        // Not necessary to delete barrows if cascade is set, but try:
                        // NOTE: Only delete our test ISBN
                        // No delete method in BarrowRepo, implement if needed
                    }
                }

                _bookRepo.Delete(_testIsbn);
                _userRepo.Delete(_testUserId);
            }
            catch
            {
                // Silent fail, e.g. cleanup error
            }
        }
    }
}
