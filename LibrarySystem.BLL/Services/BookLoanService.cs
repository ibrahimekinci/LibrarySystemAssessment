using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.Services;
using LibrarySystem.Domain.Entities;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LibrarySystem.BLL.Services
{
    public class BookLoanService : BaseService, IBookLoanService
    {
        public int Borrow(BorrowCreateDto borrow)
        {
            var entity = Mapper.Map<BorrowEntity>(borrow);
            return BookLoanRepository.Add(entity);
        }

        public bool Return(BorrowReturnDto borrow)
        {
            return BookLoanRepository.Return(borrow.BID, borrow.ActualReturnDate, borrow.LateFee);
        }
        public bool Delete(int borrowId)
        {
            var record = BookLoanRepository.GetById(borrowId);
            if (record == null)
                return false;

            return BookLoanRepository.Delete(borrowId);
        }

        public BorrowViewDto GetById(int id)
        {
            var entity = BookLoanRepository.GetById(id);
            return Mapper.Map<BorrowViewDto>(entity);
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
