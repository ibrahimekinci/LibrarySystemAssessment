using LibrarySystem.BLL.DTOs;
using System.Collections.Generic;
using System.Data;

namespace LibrarySystem.BLL.Interfaces
{
    public interface IBookLoanService
    {
        int BorrowBook(BarrowCreateDto barrowRecord);
        bool ReturnBook(BarrowReturnDto barrowRecord);
        BarrowViewDto GetById(int id);
        List<BarrowViewDto> GetByUserId(int userId);
        DataTable GetUnreturnedLoansByUserId(int userId);
        DataTable GetAllLoans();
        DataTable GetLoansByUserId(int uid);
        bool Delete(int borrowId);
    }

}
