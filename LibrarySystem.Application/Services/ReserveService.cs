using LibrarySystem.BLL.DTOs;
using LibrarySystem.BLL.Interfaces;
using System.Collections.Generic;

namespace LibrarySystem.BLL.Services
{
    public class ReserveService : BaseService, IReserveService
    {

        public List<ReserveViewDto> GetReservationsByUser(int userId)
        {
            throw new System.NotImplementedException();
        }

        public int ReserveBook(ReserveCreateDto reserveRecordDto)
        {
            throw new System.NotImplementedException();
        }

        public int UpdateBookReservation(ReserveUpdateDto reserveRecordDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
