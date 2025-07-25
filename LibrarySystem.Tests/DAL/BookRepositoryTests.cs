using LibrarySystem.DAL.Repositories;
using LibrarySystem.Domain.Entities;
using LibrarySystem.Abstractions.DTOs;

namespace LibrarySystem.Tests.Integration.DAL
{
    public class BookRepositoryTests
    {
        private readonly BookRepository _repo = new();

        private BookEntity CreateTestBook(string suffix = null)
        {
            suffix += Guid.NewGuid().ToString("N").Substring(0, 5);
            return new BookEntity
            {
                ISBN = "ISBN_" + suffix,
                BookName = "TestBook_" + suffix,
                Author = 1,
                Category = 1,
                Language = 1,
                PublishYear = 2020,
                Pages = 300,
                Publisher = "Publisher_" + suffix
            };
        }

        [Fact]
        public void Add_Should_Insert_Book_And_Verify_All_Fields()
        {
            // Arrange
            var book = CreateTestBook();

            // Act
            var isbn = _repo.Add(book);

            // Assert
            Assert.False(string.IsNullOrEmpty(isbn));
            var fetched = _repo.GetByISBN(book.ISBN);
            Assert.NotNull(fetched);
            Assert.Equal(book.ISBN, fetched.ISBN);
            Assert.Equal(book.BookName, fetched.BookName);
            Assert.Equal(book.Author, fetched.Author);
            Assert.Equal(book.Category, fetched.Category);
            Assert.Equal(book.Language, fetched.Language);
            Assert.Equal(book.PublishYear, fetched.PublishYear);
            Assert.Equal(book.Pages, fetched.Pages);
            Assert.Equal(book.Publisher, fetched.Publisher);

            // Cleanup
            _repo.Delete(book.ISBN);
        }

        [Fact]
        public void GetByISBN_Should_Return_Correct_Book()
        {
            // Arrange
            var book = CreateTestBook();
            var addedBookISBN = _repo.Add(book);

            // Act
            var result = _repo.GetByISBN(book.ISBN);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(book.ISBN, result.ISBN);

            // Cleanup
            _repo.Delete(book.ISBN);
        }

        [Fact]
        public void Update_Should_Modify_All_Fields()
        {
            // Arrange
            var book = CreateTestBook();
            _repo.Add(book);

            // Modify all fields
            book.BookName = "Updated Book Name";
            book.Author = 2;
            book.Category = 2;
            book.Language = 2;
            book.PublishYear = 2025;
            book.Pages = 999;
            book.Publisher = "Updated Publisher";

            // Act
            var result = _repo.Update(book);

            // Assert
            Assert.True(result);
            var fetched = _repo.GetByISBN(book.ISBN);

            Assert.Equal(book.ISBN, fetched.ISBN);
            Assert.Equal(book.BookName, fetched.BookName);
            Assert.Equal(book.Author, fetched.Author);
            Assert.Equal(book.Category, fetched.Category);
            Assert.Equal(book.Language, fetched.Language);
            Assert.Equal(book.PublishYear, fetched.PublishYear);
            Assert.Equal(book.Pages, fetched.Pages);
            Assert.Equal(book.Publisher, fetched.Publisher);

            // Cleanup
            _repo.Delete(book.ISBN);
        }

        [Fact]
        public void Delete_Should_Remove_Book()
        {
            // Arrange
            var book = CreateTestBook();
            _repo.Add(book);

            // Act
            var deleted = _repo.Delete(book.ISBN);

            // Assert
            Assert.True(deleted);
            var result = _repo.GetByISBN(book.ISBN);
            Assert.Null(result);
        }

        [Fact]
        public void GetAll_Should_Return_NonNull_List()
        {
            var list = _repo.GetAll();
            Assert.NotNull(list);
        }

        [Fact]
        public void GetAllBookAvailable_Should_Return_NonNull_List()
        {
            var list = _repo.GetAllBookAvailable();
            Assert.NotNull(list);
        }

       
        [Fact]
        public void Search_With_All_Fields_Should_Return_Matching_Book()
        {
            // Arrange
            var book = CreateTestBook();
            _repo.Add(book);

            var addedBook = _repo.GetByISBN(book.ISBN);

            var dto = new BookSearchCriteriaDto
            {
                BookName = book.BookName,
                AuthorName = addedBook.AuthorName,
                CategoryId = 1
            };

            // Act
            var result = _repo.Search(dto);

            // Assert
            Assert.Contains(result, x => x.ISBN == book.ISBN);

            // Cleanup
            _repo.Delete(book.ISBN);
        }

        [Fact]
        public void Search_With_Only_BookName_Should_Return_Result()
        {
            // Arrange
            var book = CreateTestBook();
            _repo.Add(book);

            var dto = new BookSearchCriteriaDto
            {
                BookName = book.BookName,
                AuthorName = "",
                CategoryId = 0
            };

            // Act
            var result = _repo.Search(dto);

            // Assert
            Assert.Contains(result, x => x.ISBN == book.ISBN);

            // Cleanup
            _repo.Delete(book.ISBN);
        }

        [Fact]
        public void Search_With_Only_Author_Should_Return_Result()
        {
            // Arrange
            var book = CreateTestBook();
            _repo.Add(book);
            var addedBook = _repo.GetByISBN(book.ISBN);

            var dto = new BookSearchCriteriaDto
            {
                BookName = "",
                AuthorName = addedBook.AuthorName,
                CategoryId = 0
            };

            // Act
            var result = _repo.Search(dto);

            // Assert
            Assert.Contains(result, x => x.ISBN == book.ISBN);

            // Cleanup
            _repo.Delete(book.ISBN);
        }

        [Fact]
        public void Search_With_Only_Category_Should_Return_Result()
        {
            // Arrange
            var book = CreateTestBook("CAT");
            _repo.Add(book);

            var dto = new BookSearchCriteriaDto
            {
                BookName = "",
                AuthorName = "",
                CategoryId = 1
            };

            // Act
            var result = _repo.Search(dto);

            // Assert
            Assert.True(result.Any());

            // Cleanup
            _repo.Delete(book.ISBN);
        }
    }
}