using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Repositories;

namespace LibrarySystem.Tests.DAL
{
    public class AuthorRepositoryTests
    {
        private readonly AuthorRepository _repo = new();

        [Fact]
        public void Add_Should_Insert_Author_And_Exist_In_List()
        {
            // Arrange
            string testName = "TestAuthor_" + Guid.NewGuid().ToString("N").Substring(0, 6);
            var author = new AuthorEntity { AuthorName = testName };

            // Act
            int newId = _repo.Add(author);
            var list = _repo.GetAll();
            var found = list.FirstOrDefault(x => x.AID == newId);

            // Assert
            Assert.NotNull(found);
            Assert.Equal(testName, found.AuthorName);

            // Cleanup
            _repo.Delete(newId);
        }

        [Fact]
        public void GetById_Should_Return_Correct_Entity()
        {
            // Arrange
            string testName = "TestAuthor_" + Guid.NewGuid().ToString("N").Substring(0, 6);
            var author = new AuthorEntity { AuthorName = testName };
            int id = _repo.Add(author);

            // Act
            var result = _repo.GetById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(author.AuthorName, result.AuthorName);

            // Cleanup
            _repo.Delete(id);
        }

        [Fact]
        public void Update_Should_Modify_Author_Name()
        {
            // Arrange
            var originalName = "Author_" + Guid.NewGuid().ToString("N").Substring(0, 6);
            var updatedName = originalName + "_Updated";
            var author = new AuthorEntity { AuthorName = originalName };
            int id = _repo.Add(author);

            // Act
            author.AID = id;
            author.AuthorName = updatedName;
            _repo.Update(author);

            // Assert
            var updated = _repo.GetAll().FirstOrDefault(a => a.AID == id);
            Assert.NotNull(updated);
            Assert.Equal(updatedName, updated.AuthorName);

            // Cleanup
            _repo.Delete(id);
        }

        [Fact]
        public void Delete_Should_Remove_Author()
        {
            // Arrange
            var name = "ToDelete_" + Guid.NewGuid().ToString("N").Substring(0, 6);
            int id = _repo.Add(new AuthorEntity { AuthorName = name });

            // Act
            _repo.Delete(id);

            // Assert
            var list = _repo.GetAll();
            var deleted = list.FirstOrDefault(a => a.AID == id);
            Assert.Null(deleted);
        }
    }
}
