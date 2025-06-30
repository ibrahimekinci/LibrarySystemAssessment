using LibrarySystem.BLL.DTOs;
using LibrarySystem.BLL.Interfaces;

namespace LibrarySystem.BLL.Services
{
    public class ReserveService : BaseService, IReserveService
    {
        public PagedResultDto<ReserveViewDto> GetReservationsByUser(PagedRequestDto pagedRequestDto, int userId)
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
