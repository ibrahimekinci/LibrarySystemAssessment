using LibrarySystem.Domain.Entities;
using System.Collections.Generic;
using System.Data;

namespace LibrarySystem.Abstractions.Repositories
{
    public interface IBookLoanRepository
    {
        //PagedResultDto<List<BorrowEntity>> GetAllPaged(PagedRequestDto request);
        //PagedResultDto<List<BorrowEntity>> GetAllPagedByUserId(int uid, PagedRequestDto request);
        List<BorrowEntity> GetAll();
        List<BorrowEntity> GetAllByUserId(int uid);
        BorrowEntity GetById(int bid);
        DataTable GetUnreturnedLoansByUserId(int UID);
        DataTable GetAllLoans();
        DataTable GetLoansByUserId(int uid);
        int Add(BorrowEntity borrow);
        bool Delete(int bid);
        bool Return(int borrowId, System.DateTime actualReturnDate, decimal lateFee);
    }
}
