using LibrarySystem.DAL.DTOs;
using LibrarySystem.DAL.Entities;
using System.Collections.Generic;
using System.Data;

namespace LibrarySystem.DAL.Interfaces
{
    public interface IReserveRepository
    {
        PagedResultDto<List<ReserveEntity>> GetByUserPaged(int uid, PagedRequestDto request);
        int Add(ReserveEntity reserve);
    }
}
