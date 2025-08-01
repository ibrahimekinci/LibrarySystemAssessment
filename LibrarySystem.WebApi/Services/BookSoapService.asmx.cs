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
        public Response<List<BookViewDto>> GetAll()
        {
            try
            {
                var result = BookService.GetAll();
                return Response<List<BookViewDto>>.Ok(result);
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<List<BookViewDto>>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public Response<BookViewDto> GetByISBN(string isbn)
        {
            try
            {
                var result = BookService.GetByISBN(isbn);
                if (result != null)
                    return Response<BookViewDto>.Ok(result);
                return Response<BookViewDto>.Fail("Book not found.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<BookViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public Response<BookViewDto> Add(BookDto dto)
        {
            try
            {
                string errorMessage = dto.CheckValidityAndGetErrors();
                if (!string.IsNullOrEmpty(errorMessage))
                    return Response<BookViewDto>.Fail(errorMessage);

                var result = BookService.Add(dto);
                if (result > 0)
                {
                    var viewDto = BookService.GetByISBN(dto.ISBN);
                    return Response<BookViewDto>.Ok(viewDto, "Book created successfully.");
                }
                return Response<BookViewDto>.Fail("Failed to create book.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<BookViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public Response<BookViewDto> Update(BookDto dto)
        {
            try
            {
                string errorMessage = dto.CheckValidityAndGetErrors();
                if (!string.IsNullOrEmpty(errorMessage))
                    return Response<BookViewDto>.Fail(errorMessage);

                var result = BookService.Update(dto);
                if (result)
                {
                    var viewDto = BookService.GetByISBN(dto.ISBN);
                    return Response<BookViewDto>.Ok(viewDto, "Book updated successfully.");
                }
                return Response<BookViewDto>.Fail("Failed to update book.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<BookViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public Response<bool> Delete(string isbn)
        {
            try
            {
                var result = BookService.Delete(isbn);
                if (result)
                    return Response<bool>.Ok(true, "Book deleted successfully.");
                return Response<bool>.Fail("Failed to delete book. Make sure you have all deleted the records that are realated with this record.");
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
        public Response<List<BookViewDto>> Search(BookSearchCriteriaDto dto)
        {
            try
            {
                var result = BookService.Search(dto);
                return Response<List<BookViewDto>>.Ok(result);
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<List<BookViewDto>>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public Response<List<BookViewDto>> GetAvailableBooks()
        {
            try
            {
                var result = BookService.GetAvailableBooks();
                return Response<List<BookViewDto>>.Ok(result);
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<List<BookViewDto>>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public Response<BookViewDto> GetAvailableBookByISBN(string isbn)
        {
            try
            {
                var result = BookService.GetAvailableBookByISBN(isbn);
                if (result != null)
                    return Response<BookViewDto>.Ok(result);
                return Response<BookViewDto>.Fail("Available book not found.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<BookViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public Response<BookViewDto> GetBorrowedBookByUserIdAndISBN(int userId, string isbn)
        {
            try
            {
                var result = BookService.GetBorrowedBookByUserIdAndISBN(userId, isbn);
                if (result != null)
                    return Response<BookViewDto>.Ok(result);
                return Response<BookViewDto>.Fail("Borrowed book not found.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<BookViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
