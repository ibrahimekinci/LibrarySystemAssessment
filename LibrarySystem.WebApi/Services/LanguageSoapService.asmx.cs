using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.Exceptions;
using LibrarySystem.Abstractions.Helpers;
using LibrarySystem.WebApi.Abstracts;
using LibrarySystem.WebApi.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web.Services;

namespace LibrarySystem.WebApi.Services
{
    /// <summary>
    /// Summary description for LanguageSoapService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class LanguageSoapService : BaseSoapService
    {

        [WebMethod]
        public Response<List<LanguageViewDto>> GetAll()
        {
            try
            {
                var result = LanguageService.GetAll();
                return Response<List<LanguageViewDto>>.Ok(result);
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<List<LanguageViewDto>>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public Response<LanguageViewDto> GetById(int id)
        {
            try
            {
                var result = LanguageService.GetById(id);
                if (result != null)
                    return Response<LanguageViewDto>.Ok(result);
                return Response<LanguageViewDto>.Fail("Language not found.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<LanguageViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public Response<LanguageViewDto> Add(LanguageCreateDto dto)
        {
            try
            {
                string errorMessage = dto.CheckValidityAndGetErrors();
                if (!string.IsNullOrEmpty(errorMessage))
                    return Response<LanguageViewDto>.Fail(errorMessage);

                var result = LanguageService.Add(dto);
                if (result > 0)
                {
                    var viewDto = LanguageService.GetById(result);
                    return Response<LanguageViewDto>.Ok(viewDto, "Language created successfully.");
                }
                return Response<LanguageViewDto>.Fail("Failed to create language.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<LanguageViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public Response<LanguageViewDto> Update(LanguageUpdateDto dto)
        {
            try
            {
                string errorMessage = dto.CheckValidityAndGetErrors();
                if (!string.IsNullOrEmpty(errorMessage))
                    return Response<LanguageViewDto>.Fail(errorMessage);

                var result = LanguageService.Update(dto);
                if (result)
                {
                    var viewDto = LanguageService.GetById(dto.LID);
                    return Response<LanguageViewDto>.Ok(viewDto, "Language updated successfully.");
                }
                return Response<LanguageViewDto>.Fail("Failed to update language.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<LanguageViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public Response<bool> Delete(int languageId)
        {
            try
            {
                var result = LanguageService.Delete(languageId);
                if (result)
                    return Response<bool>.Ok(true, "Language deleted successfully.");
                return Response<bool>.Fail("Failed to delete language.Make sure you have all deleted the records that are realated with this record.");
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
