using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.Enums;
using LibrarySystem.Abstractions.Exceptions;
using LibrarySystem.Abstractions.Helpers;
using LibrarySystem.WebApi.Abstracts;
using LibrarySystem.WebApi.Helpers;
using LibrarySystem.WebApi.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Services;

namespace LibrarySystem.WebApi.Services
{
    /// <summary>
    /// Summary description for AuthorSoapService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class AuthorSoapService : BaseSoapService
    {
        [WebMethod]
        [AuthorizeRole(UserLevelEnum.Manager, UserLevelEnum.Staff)]
        public Response<AuthorViewDto> Add(AuthorCreateDto dto)
        {
            try
            {
                string errorMessage = dto.CheckValidityAndGetErrors();
                if (!string.IsNullOrEmpty(errorMessage))
                    return Response<AuthorViewDto>.Fail(errorMessage);

                var result = AuthorService.Add(dto);
                if (result > 0)
                {
                    var viewDto = AuthorService.GetById(result);
                    return Response<AuthorViewDto>.Ok(viewDto, "Author created successfully.");
                }
                return Response<AuthorViewDto>.Fail("Failed to create author.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<AuthorViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        [AuthorizeRole(UserLevelEnum.Manager, UserLevelEnum.Staff)]
        public Response<AuthorViewDto> Update(AuthorUpdateDto dto)
        {
            try
            {
                string errorMessage = dto.CheckValidityAndGetErrors();
                if (!string.IsNullOrEmpty(errorMessage))
                    return Response<AuthorViewDto>.Fail(errorMessage);

                var result = AuthorService.Update(dto);
                if (result)
                {
                    var viewDto = AuthorService.GetById(dto.AID);
                    return Response<AuthorViewDto>.Ok(viewDto, "Author updated successfully.");
                }
                return Response<AuthorViewDto>.Fail("Failed to update author.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<AuthorViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        [AuthorizeRole(UserLevelEnum.Manager, UserLevelEnum.Staff)]
        public Response<bool> Delete(int id)
        {
            try
            {
                var result = AuthorService.Delete(id);
                if (result)
                    return Response<bool>.Ok(true, "Author deleted successfully.");
                return Response<bool>.Fail("Failed to delete author. Make sure you have all deleted the records that are realated with this record.");
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

        [WebMethod]
        [AuthorizeRole(UserLevelEnum.Manager, UserLevelEnum.Staff, UserLevelEnum.Student)]
        public Response<List<AuthorViewDto>> GetAll()
        {
            try
            {
                var result = AuthorService.GetAll();
                return Response<List<AuthorViewDto>>.Ok(result);
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<List<AuthorViewDto>>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        [AuthorizeRole(UserLevelEnum.Manager, UserLevelEnum.Staff, UserLevelEnum.Student)]
        public Response<AuthorViewDto> GetById(int id)
        {
            try
            {
                var result = AuthorService.GetById(id);
                if (result != null)
                    return Response<AuthorViewDto>.Ok(result);
                return Response<AuthorViewDto>.Fail("Author not found.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<AuthorViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
