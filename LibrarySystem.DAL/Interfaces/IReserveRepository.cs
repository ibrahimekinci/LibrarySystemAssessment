using LibrarySystem.DAL.Entities;
using System.Collections.Generic;
using System.Data;

namespace LibrarySystem.DAL.Interfaces
{
    public interface IReserveRepository
    {
        //PagedResultDto<List<ReserveEntity>> GetAllPaged(PagedRequestDto request);
        //PagedResultDto<List<ReserveEntity>> GetAllPagedByUserId(int uid, PagedRequestDto request);
        DataTable GetAll();
        DataTable GetAllByUserId(int userId);
        ReserveEntity GetById(int id);
        int Add(ReserveEntity reserve);
        bool Delete(int rid);

    }
}
