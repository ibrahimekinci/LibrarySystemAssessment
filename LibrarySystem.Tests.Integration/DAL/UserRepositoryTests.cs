using LibrarySystem.Domain.Entities;
using LibrarySystem.DAL.Repositories;
using LibrarySystem.Abstractions.Enums;

namespace LibrarySystem.Tests.Integration.DAL
{
    public class UserRepositoryTests : BaseDalTest
    {
        private readonly UserRepository _repo = new();

        private UserEntity CreateTestUser(string suffix = null)
        {
            suffix ??= Guid.NewGuid().ToString("N").Substring(0, 3);
            return new UserEntity
            {
                UserName = "usr_" + suffix,
                Password = "pass123",
                Email = $"test_{suffix}@test.com",
                PhoneNumber = "0400000000",
                UserLevel = (int)UserLevelEnum.Student
            };
        }

        [Fact]
        public void Add_Should_Insert_User_And_Return_Id()
        {
            // Arrange
            var user = CreateTestUser();

            // Act
            int id = _repo.Add(user);

            // Assert
            Assert.True(id > 0);
            var all = _repo.GetAll();
            var inserted = all.FirstOrDefault(x => x.UID == id);
            Assert.NotNull(inserted);
            Assert.Equal(user.UserName, inserted.UserName);
            Assert.Equal(user.Email, inserted.Email);
            Assert.Equal(user.PhoneNumber, inserted.PhoneNumber);
            Assert.Equal(user.UserLevel, inserted.UserLevel);

            // Cleanup
            _repo.Delete(id);
        }

        [Fact]
        public void Update_Should_Modify_User_Fields()
        {
            // Arrange
            var user = CreateTestUser();
            int id = _repo.Add(user);

            user.UID = id;
            user.UserName = "u" + user.UserName;
            user.Email = "updated@test.com";
            user.PhoneNumber = "0411222333";
            user.UserLevel = (int)UserLevelEnum.Manager;

            // Act
            var updated = _repo.Update(user);

            // Assert
            Assert.True(updated);
            var result = _repo.GetById(id);
            Assert.Equal(user.UserName, result.UserName);
            Assert.Equal(user.Email, result.Email);
            Assert.Equal(user.PhoneNumber, result.PhoneNumber);
            Assert.Equal(user.UserLevel, result.UserLevel);

            // Cleanup
            _repo.Delete(id);
        }

        [Fact]
        public void Delete_Should_Remove_User()
        {
            // Arrange
            var user = CreateTestUser();
            int id = _repo.Add(user);

            // Act
            var deleted = _repo.Delete(id);

            // Assert
            Assert.True(deleted);
            var result = _repo.GetById(id);
            Assert.Null(result);
        }

        [Fact]
        public void GetById_Should_Return_Correct_User()
        {
            // Arrange
            var user = CreateTestUser();
            int id = _repo.Add(user);

            // Act
            var result = _repo.GetById(id);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.UserName, result.UserName);

            // Cleanup
            _repo.Delete(id);
        }

        [Fact]
        public void GetByUsername_Should_Return_Correct_User()
        {
            // Arrange
            var user = CreateTestUser();
            int id = _repo.Add(user);

            // Act
            var result = _repo.GetByUsername(user.UserName);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(user.Email, result.Email);

            // Cleanup
            _repo.Delete(id);
        }

        [Fact]
        public void GetAll_Should_Return_User_List()
        {
            var list = _repo.GetAll();

            Assert.NotNull(list);
            Assert.True(list.Count >= 0);
        }
    }
}
