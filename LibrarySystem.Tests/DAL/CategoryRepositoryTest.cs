using LibrarySystem.DAL.Repositories;
using LibrarySystem.DAL.Entities;

namespace LibrarySystem.Tests.DAL
{
    public class CategoryRepositoryTests
    {
        private readonly CategoryRepository _repo = new();

        private CategoryEntity CreateTestCategory(string suffix = null)
        {
            suffix ??= Guid.NewGuid().ToString("N").Substring(0, 6);
            return new CategoryEntity
            {
                CategoryName = "TestCategory_" + suffix
            };
        }

        [Fact]
        public void Add_Should_Insert_And_Return_New_Id()
        {
            // Arrange
            var category = CreateTestCategory();

            // Act
            int id = _repo.Add(category);

            // Assert
            Assert.True(id > 0);
            var all = _repo.GetAll();
            var inserted = all.FirstOrDefault(c => c.CID == id);
            Assert.NotNull(inserted);
            Assert.Equal(category.CategoryName, inserted.CategoryName);

            // Cleanup
            _repo.Delete(id);
        }

        [Fact]
        public void Update_Should_Modify_Category_Name()
        {
            // Arrange
            var category = CreateTestCategory();
            int id = _repo.Add(category);

            var updatedName = category.CategoryName + "_Updated";
            category.CID = id;
            category.CategoryName = updatedName;

            // Act
            var result = _repo.Update(category);

            // Assert
            Assert.True(result);
            var updated = _repo.GetAll().FirstOrDefault(c => c.CID == id);
            Assert.Equal(updatedName, updated.CategoryName);

            // Cleanup
            _repo.Delete(id);
        }

        [Fact]
        public void Delete_Should_Remove_Category()
        {
            // Arrange
            var category = CreateTestCategory();
            int id = _repo.Add(category);

            // Act
            var result = _repo.Delete(id);

            // Assert
            Assert.True(result);
            var all = _repo.GetAll();
            Assert.DoesNotContain(all, c => c.CID == id);
        }

        [Fact]
        public void GetAll_Should_Return_Valid_List()
        {
            // Act
            var list = _repo.GetAll();

            // Assert
            Assert.NotNull(list);
            Assert.True(list.Count >= 0);
        }
    }
}
