using LibrarySystem.Application.DTOs;
using LibrarySystem.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LibrarySystem.Application.Interfaces
{
    public interface IReserveService
    {
        int ReserveBook(ReserveDto reserveRecordDto);
        int UpdateBookReservation(ReserveUpdateDto reserveRecordDto);
        PagedResultDataTableDto<ReserveViewDto> GetReservationsByUser(PagedRequestDto pagedRequestDto,int userId);
    }
}
