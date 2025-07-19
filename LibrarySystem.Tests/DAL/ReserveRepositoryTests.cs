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
        public void GetAll_Should_Return_List()
        {
            // Act
            var list = _repo.GetAll();

            // Assert
            Assert.NotNull(list);
            Assert.True(list.Rows.Count >= 0);
        }


    }
}
