using AutoMapper;
using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.Repositories;
using LibrarySystem.BLL.Services;
using LibrarySystem.Domain.Entities;
using Moq;

namespace LibrarySystem.Tests.Unit.Services
{
    public class UserServiceTests
    {
        private readonly UserService _service;
        private readonly Mock<IUserRepository> _userRepoMock;
        private readonly Mock<IMapper> _mapperMock;

        public UserServiceTests()
        {
            _userRepoMock = new Mock<IUserRepository>();
            _mapperMock = new Mock<IMapper>();
            _service = new UserService();
            // Inject repository mock into BaseService via reflection
            var userRepoField = typeof(BaseService).GetField("_userRepository", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
            userRepoField.SetValue(_service, _userRepoMock.Object);
            // Inject mapper mock into BaseService static field
            var mapperField = typeof(BaseService).GetField("_mapper", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static);
            mapperField.SetValue(null, _mapperMock.Object);
        }

        [Fact]
        public void Authenticate_ReturnsNull_WhenUserNotFound_Or_PasswordMismatch()
        {
            // Arrange
            string username = "nonexistent";
            string password = "pass";
            _userRepoMock.Setup(r => r.GetByUsername(username)).Returns((UserEntity)null);

            // Act & Assert (user not found)
            var result1 = _service.Authenticate(username, password);
            Assert.Null(result1);
            _userRepoMock.Verify(r => r.GetByUsername(username), Times.Once);

            // Arrange (user found but wrong password)
            var existingUser = new UserEntity { UID = 1, UserName = username, Password = "different" };
            _userRepoMock.Setup(r => r.GetByUsername(username)).Returns(existingUser);

            // Act
            var result2 = _service.Authenticate(username, password);

            // Assert
            Assert.Null(result2);
            _userRepoMock.Verify(r => r.GetByUsername(username), Times.Exactly(2));
        }

        [Fact]
        public void Authenticate_ReturnsDto_WhenCredentialsMatch()
        {
            // Arrange
            string username = "testuser";
            string password = "correctpass";
            var userEntity = new UserEntity { UID = 42, UserName = username, Password = password };
            var expectedDto = new AuthenticatedUserDto { UID = 42, UserName = username };
            _userRepoMock.Setup(r => r.GetByUsername(username)).Returns(userEntity);
            _mapperMock.Setup(m => m.Map<AuthenticatedUserDto>(userEntity)).Returns(expectedDto);

            // Act
            var result = _service.Authenticate(username, password);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedDto.UID, result.UID);
            Assert.Equal(expectedDto.UserName, result.UserName);
            _userRepoMock.Verify(r => r.GetByUsername(username), Times.Once);
            _mapperMock.Verify(m => m.Map<AuthenticatedUserDto>(userEntity), Times.Once);
        }

        [Fact]
        public void Register_CallsAddAndReturnsNewId()
        {
            // Arrange
            var dto = new UserCreateDto { UserName = "newuser", Password = "pw", Email = "test@example.com" };
            var mappedEntity = new UserEntity { UserName = dto.UserName, Password = dto.Password, Email = dto.Email };
            _mapperMock.Setup(m => m.Map<UserEntity>(dto)).Returns(mappedEntity);
            _userRepoMock.Setup(r => r.Add(mappedEntity)).Returns(100);

            // Act
            int newId = _service.Register(dto);

            // Assert
            Assert.Equal(100, newId);
            _userRepoMock.Verify(r => r.Add(mappedEntity), Times.Once);
        }

        [Fact]
        public void UpdateUser_ReturnsTrue_WhenUpdateSucceeds()
        {
            // Arrange
            var dto = new UserUpdateDto { UID = 6, UserName = "user6", Email = "user6@example.com" };
            var mappedEntity = new UserEntity { UID = dto.UID, UserName = dto.UserName, Email = dto.Email };
            _mapperMock.Setup(m => m.Map<UserEntity>(dto)).Returns(mappedEntity);
            _userRepoMock.Setup(r => r.Update(mappedEntity)).Returns(true);

            // Act
            bool result = _service.UpdateUser(dto);

            // Assert
            Assert.True(result);
            _userRepoMock.Verify(r => r.Update(mappedEntity), Times.Once);
        }

        [Fact]
        public void ResetPassword_ReturnsFalse_IfUserNotFound()
        {
            // Arrange
            var dto = new UserPasswordUpdateDto { UID = 10, NewPassword = "newpass" };
            _userRepoMock.Setup(r => r.GetById(dto.UID)).Returns((UserEntity)null);

            // Act
            bool result = _service.ResetPassword(dto);

            // Assert
            Assert.False(result);
            _userRepoMock.Verify(r => r.GetById(dto.UID), Times.Once);
            _userRepoMock.Verify(r => r.UpdatePasswordByUserId(It.IsAny<int>(), It.IsAny<string>()), Times.Never);
        }

        [Fact]
        public void ResetPassword_UpdatesPassword_WhenUserExists()
        {
            // Arrange
            var userEntity = new UserEntity { UID = 11, Password = "oldpass" };
            var dto = new UserPasswordUpdateDto { UID = 11, NewPassword = "newpass" };
            _userRepoMock.Setup(r => r.GetById(dto.UID)).Returns(userEntity);
            _userRepoMock.Setup(r => r.UpdatePasswordByUserId(dto.UID, dto.NewPassword)).Returns(true);

            // Act
            bool result = _service.ResetPassword(dto);

            // Assert
            Assert.True(result);
            Assert.Equal(dto.NewPassword, userEntity.Password);
            _userRepoMock.Verify(r => r.UpdatePasswordByUserId(dto.UID, dto.NewPassword), Times.Once);
        }

        [Fact]
        public void GetAll_ReturnsEmptyList_WhenNoUsers()
        {
            // Arrange
            _userRepoMock.Setup(r => r.GetAll()).Returns((List<UserEntity>)null);

            // Act
            var result = _service.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.Empty(result);
            _userRepoMock.Verify(r => r.GetAll(), Times.Once);
        }

        [Fact]
        public void GetAll_ReturnsMappedUserList()
        {
            // Arrange
            var users = new List<UserEntity>
            {
                new UserEntity { UID = 1, UserName = "u1" },
                new UserEntity { UID = 2, UserName = "u2" }
            };
            var viewDtos = new List<UserViewDto>
            {
                new UserViewDto { UID = 1, UserName = "u1" },
                new UserViewDto { UID = 2, UserName = "u2" }
            };
            _userRepoMock.Setup(r => r.GetAll()).Returns(users);
            _mapperMock.Setup(m => m.Map<List<UserViewDto>>(users)).Returns(viewDtos);

            // Act
            var result = _service.GetAll();

            // Assert
            Assert.Equal(viewDtos.Count, result.Count);
            Assert.Equal(viewDtos[0].UserName, result[0].UserName);
            _userRepoMock.Verify(r => r.GetAll(), Times.Once);
            _mapperMock.Verify(m => m.Map<List<UserViewDto>>(users), Times.Once);
        }

        [Fact]
        public void GetById_ReturnsNull_WhenNotFound()
        {
            // Arrange
            int userId = 99;
            _userRepoMock.Setup(r => r.GetById(userId)).Returns((UserEntity)null);

            // Act
            var result = _service.GetById(userId);

            // Assert
            Assert.Null(result);
            _userRepoMock.Verify(r => r.GetById(userId), Times.Once);
        }

        [Fact]
        public void GetById_ReturnsMappedUser_WhenFound()
        {
            // Arrange
            int userId = 12;
            var userEntity = new UserEntity { UID = userId, UserName = "user12" };
            var userDto = new UserViewDto { UID = userId, UserName = "user12" };
            _userRepoMock.Setup(r => r.GetById(userId)).Returns(userEntity);
            _mapperMock.Setup(m => m.Map<UserViewDto>(userEntity)).Returns(userDto);

            // Act
            var result = _service.GetById(userId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(userDto.UserName, result.UserName);
            _userRepoMock.Verify(r => r.GetById(userId), Times.Once);
            _mapperMock.Verify(m => m.Map<UserViewDto>(userEntity), Times.Once);
        }

        [Fact]
        public void Delete_CallsRepositoryDeleteAndReturnsResult()
        {
            // Arrange
            int userId = 7;
            _userRepoMock.Setup(r => r.Delete(userId)).Returns(true);

            // Act
            bool result = _service.Delete(userId);

            // Assert
            Assert.True(result);
            _userRepoMock.Verify(r => r.Delete(userId), Times.Once);
        }
    }
}
