using LibrarySystem.BLL.DTOs;
using System.Collections.Generic;

namespace LibrarySystem.BLL.Interfaces
{
    public interface IReserveService
    {
        int ReserveBook(ReserveCreateDto reserveRecordDto);
        int UpdateBookReservation(ReserveUpdateDto reserveRecordDto);
        List<ReserveViewDto> GetReservationsByUser(int userId);
    }
}
