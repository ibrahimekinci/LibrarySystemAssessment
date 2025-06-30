using LibrarySystem.DAL.DTOs;
using LibrarySystem.DAL.Entities;
using System.Collections.Generic;
using System.Data;

namespace LibrarySystem.DAL.Interfaces
{
    public interface IBorrowRepository
    {
        BarrowEntity GetById(int bid);
        PagedResultDto<List<BarrowEntity>> GetByUserPaged(int uid, PagedRequestDto request);
        int Add(BarrowEntity borrow);
        void Return(int borrowId, System.DateTime actualReturnDate);
    }
}
