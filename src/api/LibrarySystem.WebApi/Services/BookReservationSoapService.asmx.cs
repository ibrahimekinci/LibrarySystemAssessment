using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.Enums;
using LibrarySystem.Abstractions.Exceptions;
using LibrarySystem.Abstractions.Helpers;
using LibrarySystem.WebApi.Abstracts;
using LibrarySystem.WebApi.Helpers;
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
        [AuthorizeRole(UserLevelEnum.Manager, UserLevelEnum.Staff, UserLevelEnum.Student)]
        public Response<ReserveViewDto> Reserve(ReserveCreateDto dto)
        {
            try
            {
                string errorMessage = dto.CheckValidityAndGetErrors();
                if (!string.IsNullOrEmpty(errorMessage))
                    return Response<ReserveViewDto>.Fail(errorMessage);

                var result = BookReservationService.Reserve(dto);
                if (result > 0)
                {
                    var viewDto = BookReservationService.GetById(result);
                    return Response<ReserveViewDto>.Ok(viewDto, "Book reserved successfully.");
                }
                return Response<ReserveViewDto>.Fail("Failed to reserve book.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<ReserveViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        [AuthorizeRole(UserLevelEnum.Manager, UserLevelEnum.Staff, UserLevelEnum.Student)]
        public Response<ReserveViewDto> UpdateReservation(ReserveUpdateDto dto)
        {
            try
            {
                string errorMessage = dto.CheckValidityAndGetErrors();
                if (!string.IsNullOrEmpty(errorMessage))
                    return Response<ReserveViewDto>.Fail(errorMessage);

                var result = BookReservationService.UpdateReservation(dto);
                if (result)
                {
                    var viewDto = BookReservationService.GetById(dto.RID);
                    return Response<ReserveViewDto>.Ok(viewDto, "Reservation updated successfully.");
                }
                return Response<ReserveViewDto>.Fail("Failed to update reservation.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<ReserveViewDto>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }

        [WebMethod]
        [AuthorizeRole(UserLevelEnum.Manager, UserLevelEnum.Staff, UserLevelEnum.Student)]
        public Response<ReserveViewDto> GetById(int id)
        {
            try
            {
                var result = BookReservationService.GetById(id);
                if (result != null)
                    return Response<ReserveViewDto>.Ok(result);
                return Response<ReserveViewDto>.Fail("Reservation not found.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<ReserveViewDto>.Fail(customException.GetUserFriendlyMessage());
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
                var result = BookReservationService.GetAll();
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

                if (GetCurrentUser().UserLevel == UserLevelEnum.Student)
                    userId = GetCurrentUser().UID;
                var result = BookReservationService.GetAllByUserId(userId);
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
        public Response<bool> CancelReservation(int id)
        {
            try
            {
                var result = BookReservationService.CancelReservation(id);
                if (result)
                    return Response<bool>.Ok(true, "Reservation cancelled successfully.");
                return Response<bool>.Fail("Failed to cancel reservation.");
            }
            catch (System.Exception ex)
            {
                if (ex is ICustomException customException)
                {
                    if (customException.ShouldLog())
                        LogService.LogException(ex);
                    return Response<bool>.Fail(customException.GetUserFriendlyMessage());
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
