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
    /// Summary description for BookReservationSoapService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class BookReservationSoapService : BaseSoapService
    {

        [WebMethod]
        public SoapServiceResult<ReserveViewDto> Reserve(ReserveCreateDto dto)
        {
            try
            {
                string errorMessage = dto.CheckValidityAndGetErrors();
                if (!string.IsNullOrEmpty(errorMessage))
                    return SoapServiceResult<ReserveViewDto>.Fail(errorMessage);

                var result = BookReservationService.Reserve(dto);
                if (result > 0)
                {
                    var viewDto = BookReservationService.GetById(result);
                    return SoapServiceResult<ReserveViewDto>.Ok(viewDto, "Book reserved successfully.");
                }
                return SoapServiceResult<ReserveViewDto>.Fail("Failed to reserve book.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<ReserveViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public SoapServiceResult<ReserveViewDto> UpdateReservation(ReserveUpdateDto dto)
        {
            try
            {
                string errorMessage = dto.CheckValidityAndGetErrors();
                if (!string.IsNullOrEmpty(errorMessage))
                    return SoapServiceResult<ReserveViewDto>.Fail(errorMessage);

                var result = BookReservationService.UpdateReservation(dto);
                if (result)
                {
                    var viewDto = BookReservationService.GetById(dto.RID);
                    return SoapServiceResult<ReserveViewDto>.Ok(viewDto, "Reservation updated successfully.");
                }
                return SoapServiceResult<ReserveViewDto>.Fail("Failed to update reservation.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<ReserveViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        public SoapServiceResult<ReserveViewDto> GetById(int id)
        {
            try
            {
                var result = BookReservationService.GetById(id);
                if (result != null)
                    return SoapServiceResult<ReserveViewDto>.Ok(result);
                return SoapServiceResult<ReserveViewDto>.Fail("Reservation not found.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return SoapServiceResult<ReserveViewDto>.Fail(customException.GetUserFriendlyMessage());
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
                var result = BookReservationService.GetAll();
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
                var result = BookReservationService.GetAllByUserId(userId);
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
        public SoapServiceResult<bool> CancelReservation(int id)
        {
            try
            {
                var result = BookReservationService.CancelReservation(id);
                if (result)
                    return SoapServiceResult<bool>.Ok(true, "Reservation cancelled successfully.");
                return SoapServiceResult<bool>.Fail("Failed to cancel reservation.");
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
