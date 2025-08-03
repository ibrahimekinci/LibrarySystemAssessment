using AutoMapper;
using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.Repositories;
using LibrarySystem.BLL.Services;
using LibrarySystem.Domain.Entities;
using Moq;
using System.Data;

namespace LibrarySystem.Tests.Unit.Services
{
    public class BookLoanServiceTests
    {
        private readonly BookLoanService _service;
        private readonly Mock<IBookLoanRepository> _loanRepoMock;
        private readonly Mock<IMapper> _mapperMock;

        public BookLoanServiceTests()
        {
            _loanRepoMock = new Mock<IBookLoanRepository>();
            _mapperMock = new Mock<IMapper>();
            _service = new BookLoanService();
            typeof(BaseService).GetField("_bookLoanRepository", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                               .SetValue(_service, _loanRepoMock.Object);
            typeof(BaseService).GetField("_mapper", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                               .SetValue(null, _mapperMock.Object);
        }

        [Fact]
        public void Borrow_CallsAddAndReturnsLoanId()
        {
            // Arrange
            var dto = new BorrowCreateDto { UID = 1, ISBN = "ISBN123" };
            var entity = new BorrowEntity { UID = dto.UID, ISBN = dto.ISBN };
            _mapperMock.Setup(m => m.Map<BorrowEntity>(dto)).Returns(entity);
            _loanRepoMock.Setup(r => r.Add(entity)).Returns(55);

            // Act
            int resultId = _service.Borrow(dto);

            // Assert
            Assert.Equal(55, resultId);
            _loanRepoMock.Verify(r => r.Add(entity), Times.Once);
        }

        [Fact]
        public void Return_CallsRepositoryAndReturnsResult()
        {
            // Arrange
            var dto = new BorrowReturnDto { BID = 10, ActualReturnDate = DateTime.Today, LateFee = 5.0m };
            _loanRepoMock.Setup(r => r.Return(dto.BID, dto.ActualReturnDate, dto.LateFee)).Returns(true);

            // Act
            bool result = _service.Return(dto);

            // Assert
            Assert.True(result);
            _loanRepoMock.Verify(r => r.Return(dto.BID, dto.ActualReturnDate, dto.LateFee), Times.Once);
        }

        [Fact]
        public void Delete_ReturnsFalse_WhenRecordNotFound()
        {
            // Arrange
            int loanId = 99;
            _loanRepoMock.Setup(r => r.GetById(loanId)).Returns((BorrowEntity)null);

            // Act
            bool result = _service.Delete(loanId);

            // Assert
            Assert.False(result);
            _loanRepoMock.Verify(r => r.GetById(loanId), Times.Once);
            _loanRepoMock.Verify(r => r.Delete(It.IsAny<int>()), Times.Never);
        }

        [Fact]
        public void Delete_RemovesRecord_WhenFound()
        {
            // Arrange
            int loanId = 77;
            var loanEntity = new BorrowEntity { BID = loanId, ISBN = "X", UID = 7 };
            _loanRepoMock.Setup(r => r.GetById(loanId)).Returns(loanEntity);
            _loanRepoMock.Setup(r => r.Delete(loanId)).Returns(true);

            // Act
            bool result = _service.Delete(loanId);

            // Assert
            Assert.True(result);
            _loanRepoMock.Verify(r => r.Delete(loanId), Times.Once);
        }

        [Fact]
        public void GetById_ReturnsMappedDto_WhenExists()
        {
            // Arrange
            int loanId = 5;
            var loanEntity = new BorrowEntity { BID = loanId, ISBN = "X" };
            var loanDto = new BorrowViewDto { BID = loanId, ISBN = "X" };
            _loanRepoMock.Setup(r => r.GetById(loanId)).Returns(loanEntity);
            _mapperMock.Setup(m => m.Map<BorrowViewDto>(loanEntity)).Returns(loanDto);

            // Act
            var result = _service.GetById(loanId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(loanDto.BID, result.BID);
            _loanRepoMock.Verify(r => r.GetById(loanId), Times.Once);
            _mapperMock.Verify(m => m.Map<BorrowViewDto>(loanEntity), Times.Once);
        }

        [Fact]
        public void GetById_ReturnsNull_WhenNotFound()
        {
            _loanRepoMock.Setup(r => r.GetById(It.IsAny<int>())).Returns((BorrowEntity)null);
            var result = _service.GetById(123);
            Assert.Null(result);
        }

        [Fact]
        public void GetUnreturnedLoansByUserId_ReturnsDataTable()
        {
            int userId = 2;
            var table = new DataTable();
            _loanRepoMock.Setup(r => r.GetUnreturnedLoansByUserId(userId)).Returns(table);
            var result = _service.GetUnreturnedLoansByUserId(userId);
            Assert.Same(table, result);
            _loanRepoMock.Verify(r => r.GetUnreturnedLoansByUserId(userId), Times.Once);
        }

        [Fact]
        public void GetAll_ReturnsAllLoansDataTable()
        {
            var table = new DataTable();
            _loanRepoMock.Setup(r => r.GetAllLoans()).Returns(table);
            var result = _service.GetAll();
            Assert.Same(table, result);
            _loanRepoMock.Verify(r => r.GetAllLoans(), Times.Once);
        }

        [Fact]
        public void GetAllByUserId_ReturnsLoansForUser()
        {
            int userId = 3;
            var table = new DataTable();
            _loanRepoMock.Setup(r => r.GetLoansByUserId(userId)).Returns(table);
            var result = _service.GetAllByUserId(userId);
            Assert.Same(table, result);
            _loanRepoMock.Verify(r => r.GetLoansByUserId(userId), Times.Once);
        }
    }
}
