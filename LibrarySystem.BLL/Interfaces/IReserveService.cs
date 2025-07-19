using LibrarySystem.BLL.DTOs;
using System.Collections.Generic;
using System.Data;

namespace LibrarySystem.BLL.Interfaces
{
    public interface IReserveService
    {
        int ReserveBook(ReserveCreateDto reserveRecordDto);
        bool UpdateBookReservation(ReserveUpdateDto reserveRecordDto);
        ReserveViewDto GetById(int id);
        DataTable GetAll();
        DataTable GetAllByUserId(int userId);
        bool CancelReservation(int id);
    }
}
