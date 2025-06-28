using LibrarySystem.Application.DTOs;
using LibrarySystem.Application.Interfaces;

namespace LibrarySystem.Application.Services
{
    public class ReserveService : IReserveService
    {
        public PagedResultDataTableDto<ReserveViewDto> GetReservationsByUser(PagedRequestDto pagedRequestDto, int userId)
        {
            throw new System.NotImplementedException();
        }

        public int ReserveBook(ReserveDto reserveRecordDto)
        {
            throw new System.NotImplementedException();
        }

        public int UpdateBookReservation(ReserveUpdateDto reserveRecordDto)
        {
            throw new System.NotImplementedException();
        }
    }
}
