using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.Exceptions;
using LibrarySystem.BLL.Helpers;
using LibrarySystem.WebApi.Abstracts;
using LibrarySystem.WebApi.Models;
using System.Data;
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
        public SoapServiceResult<BorrowViewDto> Borrow(BorrowCreateDto dto)
        {
            try
            {
                string errorMessage = dto.CheckValidityAndGetErrors();
                if (!string.IsNullOrEmpty(errorMessage))
                    return SoapServiceResult<BorrowViewDto>.Fail(errorMessage);

                var result = BookLoanService.Borrow(dto);
                if (result > 0)
                {
                    var viewDto = BookLoanService.GetById(result);
                    return SoapServiceResult<BorrowViewDto>.Ok(viewDto, "Book borrowed successfully.");
                }
                return SoapServiceResult<BorrowViewDto>.Fail("Failed to borrow book.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<BorrowViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public SoapServiceResult<BorrowViewDto> Return(BorrowReturnDto dto)
        {
            try
            {
                string errorMessage = dto.CheckValidityAndGetErrors();
                if (!string.IsNullOrEmpty(errorMessage))
                    return SoapServiceResult<BorrowViewDto>.Fail(errorMessage);

                var result = BookLoanService.Return(dto);
                if (result)
                {
                    var viewDto = BookLoanService.GetById(dto.BID);
                    return SoapServiceResult<BorrowViewDto>.Ok(viewDto, "Book returned successfully.");
                }
                return SoapServiceResult<BorrowViewDto>.Fail("Failed to return book.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<BorrowViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public SoapServiceResult<BorrowViewDto> GetById(int id)
        {
            try
            {
                var result = BookLoanService.GetById(id);
                if (result != null)
                    return SoapServiceResult<BorrowViewDto>.Ok(result);
                return SoapServiceResult<BorrowViewDto>.Fail("Loan not found.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<BorrowViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public SoapServiceResult<DataTable> GetUnreturnedLoansByUserId(int userId)
        {
            try
            {
                var result = BookLoanService.GetUnreturnedLoansByUserId(userId);
                return SoapServiceResult<DataTable>.Ok(result);
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<DataTable>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public SoapServiceResult<DataTable> GetAll()
        {
            try
            {
                var result = BookLoanService.GetAll();
                return SoapServiceResult<DataTable>.Ok(result);
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<DataTable>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public SoapServiceResult<DataTable> GetAllByUserId(int userId)
        {
            try
            {
                var result = BookLoanService.GetAllByUserId(userId);
                return SoapServiceResult<DataTable>.Ok(result);
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<DataTable>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public SoapServiceResult<bool> Delete(int borrowId)
        {
            try
            {
                var result = BookLoanService.Delete(borrowId);
                if (result)
                    return SoapServiceResult<bool>.Ok(true, "Loan deleted successfully.");
                return SoapServiceResult<bool>.Fail("Failed to delete loan.");
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
