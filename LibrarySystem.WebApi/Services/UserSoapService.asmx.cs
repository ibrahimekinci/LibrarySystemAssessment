using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.Exceptions;
using LibrarySystem.BLL.Helpers;
using LibrarySystem.WebApi.Abstracts;
using LibrarySystem.WebApi.Models;
using System.Collections.Generic;
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
        public SoapServiceResult<UserViewDto> Register(UserCreateDto dto)
        {
            try
            {
                string errorMessage = dto.CheckValidityAndGetErrors();
                if (!string.IsNullOrEmpty(errorMessage))
                    return SoapServiceResult<UserViewDto>.Fail(errorMessage);

                var result = UserService.Register(dto);
                if (result > 0)
                {
                    var viewDto = UserService.GetById(result);
                    return SoapServiceResult<UserViewDto>.Ok(viewDto, "User registered successfully.");
                }
                return SoapServiceResult<UserViewDto>.Fail("Failed to register user.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<UserViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public SoapServiceResult<UserViewDto> UpdateUser(UserUpdateDto dto)
        {
            try
            {
                string errorMessage = dto.CheckValidityAndGetErrors();
                if (!string.IsNullOrEmpty(errorMessage))
                    return SoapServiceResult<UserViewDto>.Fail(errorMessage);

                var result = UserService.UpdateUser(dto);
                if (result)
                {
                    var viewDto = UserService.GetById(dto.UID);
                    return SoapServiceResult<UserViewDto>.Ok(viewDto, "User updated successfully.");
                }
                return SoapServiceResult<UserViewDto>.Fail("Failed to update user.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<UserViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public SoapServiceResult<UserViewDto> ResetPassword(UserPasswordUpdateDto dto)
        {
            try
            {
                string errorMessage = dto.CheckValidityAndGetErrors();
                if (!string.IsNullOrEmpty(errorMessage))
                    return SoapServiceResult<UserViewDto>.Fail(errorMessage);

                var result = UserService.ResetPassword(dto);
                if (result)
                {
                    var viewDto = UserService.GetById(dto.UID);
                    return SoapServiceResult<UserViewDto>.Ok(viewDto, "Password reset successfully.");
                }
                return SoapServiceResult<UserViewDto>.Fail("Failed to reset password.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<UserViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public SoapServiceResult<List<UserViewDto>> GetAll()
        {
            try
            {
                var result = UserService.GetAll();
                return SoapServiceResult<List<UserViewDto>>.Ok(result);
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<List<UserViewDto>>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public SoapServiceResult<UserViewDto> GetById(int userId)
        {
            try
            {
                var result = UserService.GetById(userId);
                if (result != null)
                    return SoapServiceResult<UserViewDto>.Ok(result);
                return SoapServiceResult<UserViewDto>.Fail("User not found.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<UserViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public SoapServiceResult<bool> Delete(int userId)
        {
            try
            {
                var result = UserService.Delete(userId);
                if (result)
                    return SoapServiceResult<bool>.Ok(true, "User deleted successfully.");
                return SoapServiceResult<bool>.Fail("Failed to delete user.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<bool>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
