using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.Exceptions;
using LibrarySystem.Abstractions.Services;
using LibrarySystem.Domain.Entities;
using System.Collections.Generic;

namespace LibrarySystem.BLL.Services
{
    public class UserService : BaseService, IUserService
    {
        public int Register(UserCreateDto dto)
        {
            var existEntity = UserRepository.GetByUsername(dto.UserName);
            if (existEntity != null && existEntity.UID > 0)
                throw new ConflictException("UserName is already being used.");

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
