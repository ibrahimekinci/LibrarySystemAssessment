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
    /// Summary description for BookSoapService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BookSoapService : BaseSoapService
    {

        [WebMethod]
        public SoapServiceResult<List<BookViewDto>> GetAll()
        {
            try
            {
                var result = BookService.GetAll();
                return SoapServiceResult<List<BookViewDto>>.Ok(result);
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<List<BookViewDto>>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public SoapServiceResult<BookViewDto> GetByISBN(string isbn)
        {
            try
            {
                var result = BookService.GetByISBN(isbn);
                if (result != null)
                    return SoapServiceResult<BookViewDto>.Ok(result);
                return SoapServiceResult<BookViewDto>.Fail("Book not found.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<BookViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public SoapServiceResult<BookViewDto> Add(BookDto dto)
        {
            try
            {
                string errorMessage = dto.CheckValidityAndGetErrors();
                if (!string.IsNullOrEmpty(errorMessage))
                    return SoapServiceResult<BookViewDto>.Fail(errorMessage);

                var result = BookService.Add(dto);
                if (result > 0)
                {
                    var viewDto = BookService.GetByISBN(dto.ISBN);
                    return SoapServiceResult<BookViewDto>.Ok(viewDto, "Book created successfully.");
                }
                return SoapServiceResult<BookViewDto>.Fail("Failed to create book.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<BookViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public SoapServiceResult<BookViewDto> Update(BookDto dto)
        {
            try
            {
                string errorMessage = dto.CheckValidityAndGetErrors();
                if (!string.IsNullOrEmpty(errorMessage))
                    return SoapServiceResult<BookViewDto>.Fail(errorMessage);

                var result = BookService.Update(dto);
                if (result)
                {
                    var viewDto = BookService.GetByISBN(dto.ISBN);
                    return SoapServiceResult<BookViewDto>.Ok(viewDto, "Book updated successfully.");
                }
                return SoapServiceResult<BookViewDto>.Fail("Failed to update book.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<BookViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public SoapServiceResult<bool> Delete(string isbn)
        {
            try
            {
                var result = BookService.Delete(isbn);
                if (result)
                    return SoapServiceResult<bool>.Ok(true, "Book deleted successfully.");
                return SoapServiceResult<bool>.Fail("Failed to delete book.");
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
        public SoapServiceResult<List<BookViewDto>> Search(BookSearchCriteriaDto dto)
        {
            try
            {
                var result = BookService.Search(dto);
                return SoapServiceResult<List<BookViewDto>>.Ok(result);
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<List<BookViewDto>>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public SoapServiceResult<List<BookViewDto>> GetAvailableBooks()
        {
            try
            {
                var result = BookService.GetAvailableBooks();
                return SoapServiceResult<List<BookViewDto>>.Ok(result);
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<List<BookViewDto>>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public SoapServiceResult<BookViewDto> GetAvailableBookByISBN(string isbn)
        {
            try
            {
                var result = BookService.GetAvailableBookByISBN(isbn);
                if (result != null)
                    return SoapServiceResult<BookViewDto>.Ok(result);
                return SoapServiceResult<BookViewDto>.Fail("Available book not found.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<BookViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public SoapServiceResult<BookViewDto> GetBorrowedBookByUserIdAndISBN(int userId, string isbn)
        {
            try
            {
                var result = BookService.GetBorrowedBookByUserIdAndISBN(userId, isbn);
                if (result != null)
                    return SoapServiceResult<BookViewDto>.Ok(result);
                return SoapServiceResult<BookViewDto>.Fail("Borrowed book not found.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<BookViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
