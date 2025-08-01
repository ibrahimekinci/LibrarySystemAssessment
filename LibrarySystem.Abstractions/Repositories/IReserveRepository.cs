using LibrarySystem.Domain.Entities;
using System.Data;

namespace LibrarySystem.Abstractions.Repositories
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
