using LibrarySystem.BLL.DTOs;
using System.Data;

namespace LibrarySystem.BLL.Interfaces
{
    public interface IBookLoanService
    {
        int Borrow(BarrowCreateDto barrowRecord);
        bool Return(BarrowReturnDto barrowRecord);
        BarrowViewDto GetById(int id);
        DataTable GetUnreturnedLoansByUserId(int userId);
        DataTable GetAll();
        DataTable GetAllByUserId(int uid);
        bool Delete(int borrowId);
    }

}
