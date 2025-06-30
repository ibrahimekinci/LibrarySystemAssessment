using LibrarySystem.BLL.DTOs;

namespace LibrarySystem.BLL.Interfaces
{
    public interface IReserveService
    {
        int ReserveBook(ReserveCreateDto reserveRecordDto);
        int UpdateBookReservation(ReserveUpdateDto reserveRecordDto);
        PagedResultDto<ReserveViewDto> GetReservationsByUser(PagedRequestDto pagedRequestDto,int userId);
    }
}
