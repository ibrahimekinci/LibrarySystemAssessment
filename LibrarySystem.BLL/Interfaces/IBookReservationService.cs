using LibrarySystem.BLL.DTOs;
using System.Data;

namespace LibrarySystem.BLL.Interfaces
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
