using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.Enums;
using LibrarySystem.Abstractions.Exceptions;
using LibrarySystem.Abstractions.Helpers;
using LibrarySystem.WebApi.Abstracts;
using LibrarySystem.WebApi.Helpers;
using LibrarySystem.WebApi.Models;
using System.Data;
using System.Data.SqlClient;
using System.Web.Services;

namespace LibrarySystem.WebApi.Services
{
    /// <summary>
    /// Summary description for BookLoanSoapService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BookLoanSoapService : BaseSoapService
    {

        [WebMethod]
        [AuthorizeRole(UserLevelEnum.Manager, UserLevelEnum.Staff, UserLevelEnum.Student)]
        public Response<BorrowViewDto> Borrow(BorrowCreateDto dto)
        {
            try
            {
                string errorMessage = dto.CheckValidityAndGetErrors();
                if (!string.IsNullOrEmpty(errorMessage))
                    return Response<BorrowViewDto>.Fail(errorMessage);

                var result = BookLoanService.Borrow(dto);
                if (result > 0)
                {
                    var viewDto = BookLoanService.GetById(result);
                    return Response<BorrowViewDto>.Ok(viewDto, "Book borrowed successfully.");
                }
                return Response<BorrowViewDto>.Fail("Failed to borrow book.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<BorrowViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        [AuthorizeRole(UserLevelEnum.Manager, UserLevelEnum.Staff, UserLevelEnum.Student)]
        public Response<BorrowViewDto> Return(BorrowReturnDto dto)
        {
            try
            {
                string errorMessage = dto.CheckValidityAndGetErrors();
                if (!string.IsNullOrEmpty(errorMessage))
                    return Response<BorrowViewDto>.Fail(errorMessage);

                var result = BookLoanService.Return(dto);
                if (result)
                {
                    var viewDto = BookLoanService.GetById(dto.BID);
                    return Response<BorrowViewDto>.Ok(viewDto, "Book returned successfully.");
                }
                return Response<BorrowViewDto>.Fail("Failed to return book.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<BorrowViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        [AuthorizeRole(UserLevelEnum.Manager, UserLevelEnum.Staff, UserLevelEnum.Student)]
        public Response<BorrowViewDto> GetById(int id)
        {
            try
            {
                var result = BookLoanService.GetById(id);
                if (result != null)
                    return Response<BorrowViewDto>.Ok(result);
                return Response<BorrowViewDto>.Fail("Loan not found.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<BorrowViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        [AuthorizeRole(UserLevelEnum.Manager, UserLevelEnum.Staff, UserLevelEnum.Student)]
        public Response<DataTable> GetUnreturnedLoansByUserId(int userId)
        {
            try
            {
                var result = BookLoanService.GetUnreturnedLoansByUserId(userId);
                return Response<DataTable>.Ok(result);
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<DataTable>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        [AuthorizeRole(UserLevelEnum.Manager, UserLevelEnum.Staff)]
        public Response<DataTable> GetAll()
        {
            try
            {
                var result = BookLoanService.GetAll();
                return Response<DataTable>.Ok(result);
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<DataTable>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        [AuthorizeRole(UserLevelEnum.Manager, UserLevelEnum.Staff, UserLevelEnum.Student)]
        public Response<DataTable> GetAllByUserId(int userId)
        {
            try
            {
                if (GetCurrentUser().UserLevel == UserLevelEnum.Student &&
                      userId != GetCurrentUser().UID)
                    return Response<DataTable>.Fail("Invalid token for this operation");

                var result = BookLoanService.GetAllByUserId(userId);
                return Response<DataTable>.Ok(result);
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<DataTable>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        [AuthorizeRole(UserLevelEnum.Manager, UserLevelEnum.Staff)]
        public Response<bool> Delete(int borrowId)
        {
            try
            {
                var result = BookLoanService.Delete(borrowId);
                if (result)
                    return Response<bool>.Ok(true, "Loan deleted successfully.");
                return Response<bool>.Fail("Failed to delete loan. Make sure you have all deleted the records that are realated with this record.");
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
