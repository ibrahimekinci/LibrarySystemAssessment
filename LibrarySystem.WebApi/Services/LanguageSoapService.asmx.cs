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
        public SoapServiceResult<List<LanguageViewDto>> GetAll()
        {
            try
            {
                var result = LanguageService.GetAll();
                return SoapServiceResult<List<LanguageViewDto>>.Ok(result);
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<List<LanguageViewDto>>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public SoapServiceResult<LanguageViewDto> GetById(int id)
        {
            try
            {
                var result = LanguageService.GetById(id);
                if (result != null)
                    return SoapServiceResult<LanguageViewDto>.Ok(result);
                return SoapServiceResult<LanguageViewDto>.Fail("Language not found.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<LanguageViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public SoapServiceResult<LanguageViewDto> Add(LanguageCreateDto dto)
        {
            try
            {
                string errorMessage = dto.CheckValidityAndGetErrors();
                if (!string.IsNullOrEmpty(errorMessage))
                    return SoapServiceResult<LanguageViewDto>.Fail(errorMessage);

                var result = LanguageService.Add(dto);
                if (result > 0)
                {
                    var viewDto = LanguageService.GetById(result);
                    return SoapServiceResult<LanguageViewDto>.Ok(viewDto, "Language created successfully.");
                }
                return SoapServiceResult<LanguageViewDto>.Fail("Failed to create language.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<LanguageViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public SoapServiceResult<LanguageViewDto> Update(LanguageUpdateDto dto)
        {
            try
            {
                string errorMessage = dto.CheckValidityAndGetErrors();
                if (!string.IsNullOrEmpty(errorMessage))
                    return SoapServiceResult<LanguageViewDto>.Fail(errorMessage);

                var result = LanguageService.Update(dto);
                if (result)
                {
                    var viewDto = LanguageService.GetById(dto.LID);
                    return SoapServiceResult<LanguageViewDto>.Ok(viewDto, "Language updated successfully.");
                }
                return SoapServiceResult<LanguageViewDto>.Fail("Failed to update language.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<LanguageViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public SoapServiceResult<bool> Delete(int languageId)
        {
            try
            {
                var result = LanguageService.Delete(languageId);
                if (result)
                    return SoapServiceResult<bool>.Ok(true, "Language deleted successfully.");
                return SoapServiceResult<bool>.Fail("Failed to delete language.");
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
