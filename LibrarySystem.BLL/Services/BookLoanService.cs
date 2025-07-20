using LibrarySystem.BLL.DTOs;
using LibrarySystem.BLL.Interfaces;
using LibrarySystem.DAL.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LibrarySystem.BLL.Services
{
    public class BookLoanService : BaseService, IBookLoanService
    {
        public int Borrow(BarrowCreateDto barrowRecord)
        {
            var entity = Mapper.Map<BarrowEntity>(barrowRecord);
            return BookLoanRepository.Add(entity);
        }

        public bool Return(BarrowReturnDto barrowRecord)
        {
            return BookLoanRepository.Return(barrowRecord.BID, barrowRecord.ActualReturnDate, barrowRecord.LateFee);
        }
        public bool Delete(int borrowId)
        {
            var record = BookLoanRepository.GetById(borrowId);
            if (record == null)
                return false;

            return BookLoanRepository.Delete(borrowId);
        }

        public BarrowViewDto GetById(int id)
        {
            var entity = BookLoanRepository.GetById(id);
            return Mapper.Map<BarrowViewDto>(entity);
        }

        public DataTable GetUnreturnedLoansByUserId(int userId)
        {
            return BookLoanRepository.GetUnreturnedLoansByUserId(userId);
        }

        public DataTable GetAll()
        {
            return BookLoanRepository.GetAllLoans();
        }

        public DataTable GetAllByUserId(int uid)
        {
            return BookLoanRepository.GetLoansByUserId(uid);
        }
    }
}
