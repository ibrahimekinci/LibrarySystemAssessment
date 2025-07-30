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
        public SoapServiceResult<AuthorViewDto> Add(AuthorCreateDto dto)
        {
            try
            {
                string errorMessage = dto.CheckValidityAndGetErrors();
                if (!string.IsNullOrEmpty(errorMessage))
                    return SoapServiceResult<AuthorViewDto>.Fail(errorMessage);

                var result = AuthorService.Add(dto);
                if (result > 0)
                {
                    var viewDto = AuthorService.GetById(result);
                    return SoapServiceResult<AuthorViewDto>.Ok(viewDto, "Author created successfully.");
                }
                return SoapServiceResult<AuthorViewDto>.Fail("Failed to create author.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<AuthorViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public SoapServiceResult<AuthorViewDto> Update(AuthorUpdateDto dto)
        {
            try
            {
                string errorMessage = dto.CheckValidityAndGetErrors();
                if (!string.IsNullOrEmpty(errorMessage))
                    return SoapServiceResult<AuthorViewDto>.Fail(errorMessage);

                var result = AuthorService.Update(dto);
                if (result)
                {
                    var viewDto = AuthorService.GetById(dto.AID);
                    return SoapServiceResult<AuthorViewDto>.Ok(viewDto, "Author updated successfully.");
                }
                return SoapServiceResult<AuthorViewDto>.Fail("Failed to update author.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<AuthorViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public SoapServiceResult<bool> Delete(int id)
        {
            try
            {
                var result = AuthorService.Delete(id);
                if (result)
                    return SoapServiceResult<bool>.Ok(true, "Author deleted successfully.");
                return SoapServiceResult<bool>.Fail("Failed to delete author.");
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

        [WebMethod]
        public SoapServiceResult<List<AuthorViewDto>> GetAll()
        {
            try
            {
                var result = AuthorService.GetAll();
                return SoapServiceResult<List<AuthorViewDto>>.Ok(result);
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<List<AuthorViewDto>>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public SoapServiceResult<AuthorViewDto> GetById(int id)
        {
            try
            {
                var result = AuthorService.GetById(id);
                if (result != null)
                    return SoapServiceResult<AuthorViewDto>.Ok(result);
                return SoapServiceResult<AuthorViewDto>.Fail("Author not found.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<AuthorViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
