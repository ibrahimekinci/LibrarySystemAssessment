using LibrarySystem.DAL.Entities;
using System.Collections.Generic;
using System.Data;

namespace LibrarySystem.DAL.Interfaces
{
    public interface IBookLoanRepository
    {
        //PagedResultDto<List<BarrowEntity>> GetAllPaged(PagedRequestDto request);
        //PagedResultDto<List<BarrowEntity>> GetAllPagedByUserId(int uid, PagedRequestDto request);
        List<BarrowEntity> GetAll();
        List<BarrowEntity> GetAllByUserId(int uid);
        BarrowEntity GetById(int bid);
        DataTable GetUnreturnedLoansByUserId(int UID);
        DataTable GetAllLoans();
        DataTable GetLoansByUserId(int uid);
        int Add(BarrowEntity borrow);
        bool Delete(int bid);
        bool Return(int borrowId, System.DateTime actualReturnDate, decimal lateFee);
    }
}
