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
    /// Summary description for CategorySoapService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class CategorySoapService : BaseSoapService
    {

        [WebMethod]
        public SoapServiceResult<List<CategoryViewDto>> GetAll()
        {
            try
            {
                var result = CategoryService.GetAll();
                return SoapServiceResult<List<CategoryViewDto>>.Ok(result);
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<List<CategoryViewDto>>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public SoapServiceResult<CategoryViewDto> GetById(int id)
        {
            try
            {
                var result = CategoryService.GetById(id);
                if (result != null)
                    return SoapServiceResult<CategoryViewDto>.Ok(result);
                return SoapServiceResult<CategoryViewDto>.Fail("Category not found.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<CategoryViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public SoapServiceResult<CategoryViewDto> Add(CategoryCreateDto dto)
        {
            try
            {
                string errorMessage = dto.CheckValidityAndGetErrors();
                if (!string.IsNullOrEmpty(errorMessage))
                    return SoapServiceResult<CategoryViewDto>.Fail(errorMessage);

                var result = CategoryService.Add(dto);
                if (result > 0)
                {
                    var viewDto = CategoryService.GetById(result);
                    return SoapServiceResult<CategoryViewDto>.Ok(viewDto, "Category created successfully.");
                }
                return SoapServiceResult<CategoryViewDto>.Fail("Failed to create category.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<CategoryViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public SoapServiceResult<CategoryViewDto> Update(CategoryUpdateDto dto)
        {
            try
            {
                string errorMessage = dto.CheckValidityAndGetErrors();
                if (!string.IsNullOrEmpty(errorMessage))
                    return SoapServiceResult<CategoryViewDto>.Fail(errorMessage);

                var result = CategoryService.Update(dto);
                if (result)
                {
                    var viewDto = CategoryService.GetById(dto.CID);
                    return SoapServiceResult<CategoryViewDto>.Ok(viewDto, "Category updated successfully.");
                }
                return SoapServiceResult<CategoryViewDto>.Fail("Failed to update category.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<CategoryViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public SoapServiceResult<bool> Delete(int categoryId)
        {
            try
            {
                var result = CategoryService.Delete(categoryId);
                if (result)
                    return SoapServiceResult<bool>.Ok(true, "Category deleted successfully.");
                return SoapServiceResult<bool>.Fail("Failed to delete category.");
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
