using LibrarySystem.DAL.Repositories;
using LibrarySystem.Domain.Entities;

namespace LibrarySystem.Tests.Integration.DAL
{
    public class CategoryRepositoryTests
    {
        private readonly CategoryRepository _repo = new CategoryRepository();

        private CategoryEntity CreateTestCategory(string suffix = null)
        {
            suffix ??= Guid.NewGuid().ToString("N").Substring(0, 6);
            return new CategoryEntity { CategoryName = "TestCategory_" + suffix };
        }

        [Fact]
        public void GetById_Should_Return_Correct_Entity()
        {
            var entity = CreateTestCategory();
            int id = _repo.Add(entity);

            var result = _repo.GetById(id);

            Assert.NotNull(result);
            Assert.Equal(entity.CategoryName, result.CategoryName);

            _repo.Delete(id);
        }

        [Fact]
        public void Add_Should_Insert_And_Return_New_Id()
        {
            var category = CreateTestCategory();

            int id = _repo.Add(category);

            Assert.True(id > 0);
            var all = _repo.GetAll();
            var inserted = all.FirstOrDefault(c => c.CID == id);
            Assert.NotNull(inserted);
            Assert.Equal(category.CategoryName, inserted.CategoryName);

            _repo.Delete(id);
        }

        [Fact]
        public void Update_Should_Modify_Category_Name()
        {
            var category = CreateTestCategory();
            int id = _repo.Add(category);
            var updatedName = category.CategoryName + "_Updated";
            category.CID = id;
            category.CategoryName = updatedName;

            bool result = _repo.Update(category);

            Assert.True(result);
            var updated = _repo.GetAll().FirstOrDefault(c => c.CID == id);
            Assert.Equal(updatedName, updated.CategoryName);

            _repo.Delete(id);
        }

        [Fact]
        public void Delete_Should_Remove_Category()
        {
            var category = CreateTestCategory();
            int id = _repo.Add(category);

            bool result = _repo.Delete(id);

            Assert.True(result);
            var all = _repo.GetAll();
            Assert.DoesNotContain(all, c => c.CID == id);
        }

        [Fact]
        public void GetAll_Should_Return_Valid_List()
        {
            var list = _repo.GetAll();

            Assert.NotNull(list);
            Assert.True(list.Count >= 0);
        }
    }
}
