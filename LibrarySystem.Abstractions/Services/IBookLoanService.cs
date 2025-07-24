using LibrarySystem.Abstractions.DTOs;
using System.Data;

namespace LibrarySystem.Abstractions.Services
{
    public interface IBookLoanService
    {
        int Borrow(BorrowCreateDto borrow);
        bool Return(BorrowReturnDto borrow);
        BorrowViewDto GetById(int id);
        DataTable GetUnreturnedLoansByUserId(int userId);
        DataTable GetAll();
        DataTable GetAllByUserId(int uid);
        bool Delete(int borrowId);
    }

}
