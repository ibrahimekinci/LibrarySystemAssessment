using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.Exceptions;
using LibrarySystem.Abstractions.Helpers;
using LibrarySystem.WebApi.Abstracts;
using LibrarySystem.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Services;

namespace LibrarySystem.WebApi.Services
{
    /// <summary>
    /// Summary description for UserSoapService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class UserSoapService : BaseSoapService
    {

        [WebMethod]
        public Response<UserViewDto> Register(UserCreateDto dto)
        {
            try
            {
                string errorMessage = dto.CheckValidityAndGetErrors();
                if (!string.IsNullOrEmpty(errorMessage))
                    return Response<UserViewDto>.Fail(errorMessage);

                var result = UserService.Register(dto);
                if (result > 0)
                {
                    var viewDto = UserService.GetById(result);
                    return Response<UserViewDto>.Ok(viewDto, "User registered successfully.");
                }
                return Response<UserViewDto>.Fail("Failed to register user.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<UserViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public Response<UserViewDto> UpdateUser(UserUpdateDto dto)
        {
            try
            {
                string errorMessage = dto.CheckValidityAndGetErrors();
                if (!string.IsNullOrEmpty(errorMessage))
                    return Response<UserViewDto>.Fail(errorMessage);

                var result = UserService.UpdateUser(dto);
                if (result)
                {
                    var viewDto = UserService.GetById(dto.UID);
                    return Response<UserViewDto>.Ok(viewDto, "User updated successfully.");
                }
                return Response<UserViewDto>.Fail("Failed to update user.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<UserViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public Response<UserViewDto> ResetPassword(UserPasswordUpdateDto dto)
        {
            try
            {
                string errorMessage = dto.CheckValidityAndGetErrors();
                if (!string.IsNullOrEmpty(errorMessage))
                    return Response<UserViewDto>.Fail(errorMessage);

                var result = UserService.ResetPassword(dto);
                if (result)
                {
                    var viewDto = UserService.GetById(dto.UID);
                    return Response<UserViewDto>.Ok(viewDto, "Password reset successfully.");
                }
                return Response<UserViewDto>.Fail("Failed to reset password.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<UserViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public Response<List<UserViewDto>> GetAll()
        {
            try
            {
                var result = UserService.GetAll();
                return Response<List<UserViewDto>>.Ok(result);
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<List<UserViewDto>>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public Response<UserViewDto> GetById(int userId)
        {
            try
            {
                var result = UserService.GetById(userId);
                if (result != null)
                    return Response<UserViewDto>.Ok(result);
                return Response<UserViewDto>.Fail("User not found.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<UserViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public Response<bool> Delete(int userId)
        {
            try
            {
                var result = UserService.Delete(userId);
                if (result)
                    return Response<bool>.Ok(true, "User deleted successfully.");
                return Response<bool>.Fail("Failed to delete user.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<bool>.Fail(customException.GetUserFriendlyMessage());
                }
                else if (ex is SqlException sqlException)
                {
                    if (sqlException.Number == 547) // Foreign key violation
                    {
                        return Response<bool>.Fail("Deletion failed due to foreign key constraint. Referencing records");
                    }
                    else
                    {
                        throw; // Re-throw other errors
                    }
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
