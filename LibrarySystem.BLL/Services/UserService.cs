using LibrarySystem.Application.DTOs;
using LibrarySystem.BLL.DTOs;
using LibrarySystem.BLL.Interfaces;
using LibrarySystem.DAL.Entities;
using System.Collections.Generic;

namespace LibrarySystem.BLL.Services
{
    public class UserService : BaseService, IUserService
    {
        public UserService()
        {
        }

        public AuthenticatedUserDto Authenticate(string username, string password)
        {
            var user = UserRepository.GetByUsername(username);
            if (user == null || user.Password != password)
                return null;

            return Mapper.Map<AuthenticatedUserDto>(user);
        }

        public int Register(UserCreateDto dto)
        {
            var entity = Mapper.Map<UserEntity>(dto);
            return UserRepository.Add(entity);
        }

        public bool UpdateUser(UserUpdateDto dto)
        {
            var entity = Mapper.Map<UserEntity>(dto);
            return UserRepository.Update(entity);
        }

        public bool ResetPassword(UserPasswordUpdateDto dto)
        {
            var user = UserRepository.GetById(dto.UID);
            if (user == null)
                return false;

            user.Password = dto.NewPassword;
            return UserRepository.UpdatePasswordByUserId(dto.UID, dto.NewPassword);
        }

        public List<UserViewDto> GetAll()
        {
            var data = UserRepository.GetAll();
            return data == null ? new List<UserViewDto>() : Mapper.Map<List<UserViewDto>>(data);
        }

        public UserViewDto GetById(int userId)
        {
            var user = UserRepository.GetById(userId);
            return user == null ? null : Mapper.Map<UserViewDto>(user);
        }

        public bool Delete(int userId)
        {
            return UserRepository.Delete(userId);
        }
    }
}
