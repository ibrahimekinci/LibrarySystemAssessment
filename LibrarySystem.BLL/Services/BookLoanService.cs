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
        public int BorrowBook(BarrowCreateDto barrowRecord)
        {
            var entity = Mapper.Map<BarrowEntity>(barrowRecord);
            return BookLoanRepository.Add(entity);
        }

        public bool ReturnBook(BarrowReturnDto barrowRecord)
        {
            return BookLoanRepository.Return(barrowRecord.BID, barrowRecord.ActualReturnDate, barrowRecord.LateFee);
        }

        public List<BarrowViewDto> GetByUserId(int userId)
        {
            var borrowRecords = BookLoanRepository.GetAllByUserId(userId);
            if (borrowRecords == null || borrowRecords.Count == 0)
                return new List<BarrowViewDto>();

            // Get matching books for the borrowed ISBNs
            var allBooks = BookRepository.GetAll();
            var borrowedBooks = from borrow in borrowRecords
                                join book in allBooks on borrow.ISBN equals book.ISBN
                                select book;

            return Mapper.Map<List<BarrowViewDto>>(borrowedBooks.ToList());
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

        public DataTable GetAllLoans()
        {
            return BookLoanRepository.GetAllLoans();
        }

        public DataTable GetLoansByUserId(int uid)
        {
            return BookLoanRepository.GetLoansByUserId(uid);
        }
    }
}
