using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Repositories;

namespace LibrarySystem.Tests.DAL
{
    public class ReserveRepositoryTests
    {
        private readonly ReserveRepository _repo = new();
        private readonly BookRepository _bookRepo = new();

        private ReserveEntity CreateTestReserve(string suffix = null)
        {
            suffix ??= Guid.NewGuid().ToString("N").Substring(0, 6);

            // Select a random existing book
            var books = _bookRepo.GetAll();
            Assert.NotNull(books);
            Assert.NotEmpty(books);
            var book = books[new Random().Next(books.Count)];

            return new ReserveEntity
            {
                UID = 1, // assumes user ID 1 exists
                ISBN = book.ISBN,
                ReservedDate = DateTime.Now,
                BookName = book.BookName
            };
        }

        [Fact]
        public void Add_Should_Insert_Reserve_And_Return_Id()
        {
            // Arrange
            var reserve = CreateTestReserve();

            // Act
            int id = _repo.Add(reserve);

            // Assert
            Assert.True(id > 0);
            var all = _repo.GetAll();
            var inserted = all.FirstOrDefault(x => x.RID == id);
            Assert.NotNull(inserted);
            Assert.Equal(reserve.ISBN, inserted.ISBN);
            Assert.Equal(reserve.UID, inserted.UID);
            Assert.Equal(reserve.ReservedDate.Date, inserted.ReservedDate.Date);

            // Cleanup
            _repo.Delete(id);
        }

        [Fact]
        public void Delete_Should_Remove_Reserve()
        {
            // Arrange
            var reserve = CreateTestReserve();
            int id = _repo.Add(reserve);

            // Act
            var deleted = _repo.Delete(id);

            // Assert
            Assert.True(deleted);
            var all = _repo.GetAll();
            Assert.DoesNotContain(all, x => x.RID == id);
        }

        [Fact]
        public void GetAll_Should_Return_List()
        {
            // Act
            var list = _repo.GetAll();

            // Assert
            Assert.NotNull(list);
            Assert.True(list.Count >= 0);
        }

        [Fact]
        public void GetByUserId_Should_Return_User_Reserves()
        {
            // Arrange
            var reserve = CreateTestReserve();
            int id = _repo.Add(reserve);

            // Act
            var userReserves = _repo.GetByUserId(reserve.UID);

            // Assert
            Assert.NotNull(userReserves);
            Assert.Contains(userReserves, r => r.RID == id);

            // Cleanup
            _repo.Delete(id);
        }
    }
}
