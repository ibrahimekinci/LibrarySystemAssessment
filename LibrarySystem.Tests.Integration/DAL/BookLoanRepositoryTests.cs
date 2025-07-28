using LibrarySystem.Domain.Entities;
using LibrarySystem.DAL.Repositories;

namespace LibrarySystem.Tests.Integration.DAL
{
    public class BookLoanRepositoryTests : BaseDalTest
    {
        private readonly BookLoanRepository _repo = new();
        private readonly BookRepository _bookRepo = new();

        private readonly List<int> _createdIds = new();

        private BorrowEntity CreateTestBorrow()
        {
            var books = _bookRepo.GetAll();
            Assert.NotNull(books);
            Assert.NotEmpty(books);

            var random = new Random();
            var randomBook = books[random.Next(books.Count)];

            return new BorrowEntity
            {
                UID = 1, // Make sure user ID 1 exists in your DB
                ISBN = randomBook.ISBN,
                BorrowDate = DateTime.Now,
                ReturnDate = DateTime.Now.AddDays(14)
            };
        }

        [Fact]
        public void Add_Should_Insert_And_Return_Valid_Id()
        {
            var borrow = CreateTestBorrow();
            int id = _repo.Add(borrow);

            Assert.True(id > 0);
            _createdIds.Add(id);

            var saved = _repo.GetById(id);
            Assert.NotNull(saved);
            Assert.Equal(borrow.UID, saved.UID);
            Assert.Equal(borrow.ISBN, saved.ISBN);
            Assert.Equal(borrow.BorrowDate.Date, saved.BorrowDate.Date);
            Assert.Equal(borrow.ReturnDate.Date, saved.ReturnDate.Date);
        }

        [Fact]
        public void GetById_Should_Return_Inserted_Record()
        {
            var borrow = CreateTestBorrow();
            int id = _repo.Add(borrow);
            _createdIds.Add(id);

            var fetched = _repo.GetById(id);

            Assert.NotNull(fetched);
            Assert.Equal(id, fetched.BID);
            Assert.Equal(borrow.UID, fetched.UID);
            Assert.Equal(borrow.ISBN, fetched.ISBN);
        }

        [Fact]
        public void GetAll_Should_Return_List()
        {
            var result = _repo.GetAll();
            Assert.NotNull(result);
            Assert.True(result.Count >= 0);
        }

        [Fact]
        public void GetAllByUserId_Should_Return_Records()
        {
            var borrow = CreateTestBorrow();
            int id = _repo.Add(borrow);
            _createdIds.Add(id);

            var result = _repo.GetAllByUserId(borrow.UID);
            Assert.NotNull(result);
            Assert.Contains(result, x => x.BID == id);
        }

        [Fact]
        public void Return_Should_Update_ActualReturnDate_And_LateFee()
        {
            var borrow = CreateTestBorrow();
            int id = _repo.Add(borrow);
            _createdIds.Add(id);

            DateTime actualReturnDate = DateTime.Now.AddDays(10);
            decimal lateFee = 5.50m;

            var success = _repo.Return(id, actualReturnDate, lateFee);

            Assert.True(success);

            var updated = _repo.GetById(id);
            Assert.NotNull(updated);
            Assert.Equal(actualReturnDate.Date, updated.ActualReturnDate.Date);
            Assert.Equal(lateFee, updated.LateFee);
        }

        public void Dispose()
        {
            foreach (var id in _createdIds)
            {
                _repo.Delete(id);
            }
        }
    }
}
