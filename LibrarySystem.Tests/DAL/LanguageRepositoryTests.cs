using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Repositories;

namespace LibrarySystem.Tests.DAL
{
    public class LanguageRepositoryTests
    {
        private readonly LanguageRepository _repo = new();

        private LanguageEntity CreateTestLanguage(string suffix = null)
        {
            suffix ??= Guid.NewGuid().ToString("N").Substring(0, 6);
            return new LanguageEntity
            {
                LanguageName = "TestLang_" + suffix
            };
        }
        [Fact]
        public void GetById_Should_Return_Correct_Entity()
        {
            // Arrange
            var entity = CreateTestLanguage();
            int id = _repo.Add(entity);

            // Act
            var result = _repo.GetById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(entity.LanguageName, result.LanguageName);

            // Cleanup
            _repo.Delete(id);
        }
        [Fact]
        public void Add_Should_Insert_Language_And_Return_Id()
        {
            // Arrange
            var lang = CreateTestLanguage();

            // Act
            int id = _repo.Add(lang);

            // Assert
            Assert.True(id > 0);
            var all = _repo.GetAll();
            var inserted = all.FirstOrDefault(x => x.LID == id);
            Assert.NotNull(inserted);
            Assert.Equal(lang.LanguageName, inserted.LanguageName);

            // Cleanup
            _repo.Delete(id);
        }

        [Fact]
        public void Update_Should_Change_Language_Name()
        {
            // Arrange
            var lang = CreateTestLanguage();
            int id = _repo.Add(lang);

            var newName = lang.LanguageName + "_Updated";
            lang.LID = id;
            lang.LanguageName = newName;

            // Act
            var result = _repo.Update(lang);

            // Assert
            Assert.True(result);
            var updated = _repo.GetAll().FirstOrDefault(x => x.LID == id);
            Assert.Equal(newName, updated.LanguageName);

            // Cleanup
            _repo.Delete(id);
        }

        [Fact]
        public void Delete_Should_Remove_Language()
        {
            // Arrange
            var lang = CreateTestLanguage();
            int id = _repo.Add(lang);

            // Act
            var deleted = _repo.Delete(id);

            // Assert
            Assert.True(deleted);
            var list = _repo.GetAll();
            Assert.DoesNotContain(list, x => x.LID == id);
        }

        [Fact]
        public void GetAll_Should_Return_Language_List()
        {
            // Act
            var list = _repo.GetAll();

            // Assert
            Assert.NotNull(list);
            Assert.True(list.Count >= 0);
        }
    }
}
