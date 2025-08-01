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
        public Response<List<CategoryViewDto>> GetAll()
        {
            try
            {
                var result = CategoryService.GetAll();
                return Response<List<CategoryViewDto>>.Ok(result);
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<List<CategoryViewDto>>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public Response<CategoryViewDto> GetById(int id)
        {
            try
            {
                var result = CategoryService.GetById(id);
                if (result != null)
                    return Response<CategoryViewDto>.Ok(result);
                return Response<CategoryViewDto>.Fail("Category not found.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<CategoryViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public Response<CategoryViewDto> Add(CategoryCreateDto dto)
        {
            try
            {
                string errorMessage = dto.CheckValidityAndGetErrors();
                if (!string.IsNullOrEmpty(errorMessage))
                    return Response<CategoryViewDto>.Fail(errorMessage);

                var result = CategoryService.Add(dto);
                if (result > 0)
                {
                    var viewDto = CategoryService.GetById(result);
                    return Response<CategoryViewDto>.Ok(viewDto, "Category created successfully.");
                }
                return Response<CategoryViewDto>.Fail("Failed to create category.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<CategoryViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public Response<CategoryViewDto> Update(CategoryUpdateDto dto)
        {
            try
            {
                string errorMessage = dto.CheckValidityAndGetErrors();
                if (!string.IsNullOrEmpty(errorMessage))
                    return Response<CategoryViewDto>.Fail(errorMessage);

                var result = CategoryService.Update(dto);
                if (result)
                {
                    var viewDto = CategoryService.GetById(dto.CID);
                    return Response<CategoryViewDto>.Ok(viewDto, "Category updated successfully.");
                }
                return Response<CategoryViewDto>.Fail("Failed to update category.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<CategoryViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public Response<bool> Delete(int categoryId)
        {
            try
            {
                var result = CategoryService.Delete(categoryId);
                if (result)
                    return Response<bool>.Ok(true, "Category deleted successfully.");
                return Response<bool>.Fail("Failed to delete category. Make sure you have all deleted the records that are realated with this record.");
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
