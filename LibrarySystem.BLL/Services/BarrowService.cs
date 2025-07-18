using LibrarySystem.BLL.DTOs;
using LibrarySystem.BLL.Interfaces;
using LibrarySystem.DAL.Entities;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem.BLL.Services
{
    public class BarrowService : BaseService, IBarrowService
    {
        public BarrowService()
        {
        }

        public int BorrowBook(BarrowCreateDto barrowRecord)
        {
            var entity = Mapper.Map<BarrowEntity>(barrowRecord);
            return BarrowRepository.Add(entity);
        }

        public bool ReturnBook(BarrowUpdateDto barrowRecord)
        {
            return BarrowRepository.Return(barrowRecord.BID, barrowRecord.ActualReturnDate, barrowRecord.LateFee);
        }

        public List<BookViewDto> GetBorrowedBooksByUser(int userId)
        {
            var borrowRecords = BarrowRepository.GetAllByUserId(userId);
            if (borrowRecords == null || borrowRecords.Count == 0)
                return new List<BookViewDto>();

            // Get matching books for the borrowed ISBNs
            var allBooks = BookRepository.GetAll();
            var borrowedBooks = from borrow in borrowRecords
                                join book in allBooks on borrow.ISBN equals book.ISBN
                                select book;

            return Mapper.Map<List<BookViewDto>>(borrowedBooks.ToList());
        }

        public bool DeleteBorrow(int borrowId)
        {
            var record = BarrowRepository.GetById(borrowId);
            if (record == null)
                return false;

            return BarrowRepository.Delete(borrowId);
        }
    }
}
