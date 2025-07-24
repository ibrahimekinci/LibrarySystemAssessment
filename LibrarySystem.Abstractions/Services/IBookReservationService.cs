using LibrarySystem.Abstractions.DTOs;
using System.Data;

namespace LibrarySystem.Abstractions.Services
{
    public interface IBookReservationService
    {
        int Reserve(ReserveCreateDto reserveRecordDto);
        bool UpdateReservation(ReserveUpdateDto reserveRecordDto);
        ReserveViewDto GetById(int id);
        DataTable GetAll();
        DataTable GetAllByUserId(int userId);
        bool CancelReservation(int id);
    }
}
