using LibrarySystem.DAL.DTOs;
using LibrarySystem.DAL.Entities;
using System.Collections.Generic;

namespace LibrarySystem.DAL.Interfaces
{
    public interface IBarrowRepository
    {
        //PagedResultDto<List<BarrowEntity>> GetAllPaged(PagedRequestDto request);
        //PagedResultDto<List<BarrowEntity>> GetAllPagedByUserId(int uid, PagedRequestDto request);
        List<BarrowEntity> GetAll();
        List<BarrowEntity> GetAllByUserId(int uid);
        BarrowEntity GetById(int bid);
        int Add(BarrowEntity borrow);
        bool Return(int borrowId, System.DateTime actualReturnDate, decimal lateFee);
    }
}
