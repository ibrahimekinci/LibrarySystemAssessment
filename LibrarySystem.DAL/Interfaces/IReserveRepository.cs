using LibrarySystem.DAL.DTOs;
using LibrarySystem.DAL.Entities;
using System.Collections.Generic;

namespace LibrarySystem.DAL.Interfaces
{
    public interface IReserveRepository
    {
        //PagedResultDto<List<ReserveEntity>> GetAllPaged(PagedRequestDto request);
        //PagedResultDto<List<ReserveEntity>> GetAllPagedByUserId(int uid, PagedRequestDto request);
        List<ReserveEntity> GetAll();
        List<ReserveEntity> GetByUserId(int uid);
        int Add(ReserveEntity reserve);
        bool Delete(int rid);

    }
}
