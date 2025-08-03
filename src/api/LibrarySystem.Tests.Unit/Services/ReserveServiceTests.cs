using AutoMapper;
using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.Repositories;
using LibrarySystem.BLL.Services;
using LibrarySystem.Domain.Entities;
using Moq;
using System.Data;
using Xunit;

namespace LibrarySystem.Tests.Unit.Services
{
    public class BookReservationServiceTests
    {
        private readonly BookReservationService _service;
        private readonly Mock<IReserveRepository> _reserveRepoMock;
        private readonly Mock<IMapper> _mapperMock;

        public BookReservationServiceTests()
        {
            _reserveRepoMock = new Mock<IReserveRepository>();
            _mapperMock = new Mock<IMapper>();
            _service = new BookReservationService();
            typeof(BaseService).GetField("_reserveRepository", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance)
                               .SetValue(_service, _reserveRepoMock.Object);
            typeof(BaseService).GetField("_mapper", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                               .SetValue(null, _mapperMock.Object);
        }

        [Fact]
        public void Reserve_AddsReservationAndReturnsId()
        {
            // Arrange
            var dto = new ReserveCreateDto { UID = 1, ISBN = "ABC123" };
            var entity = new ReserveEntity { UID = dto.UID, ISBN = dto.ISBN };
            _mapperMock.Setup(m => m.Map<ReserveEntity>(dto)).Returns(entity);
            _reserveRepoMock.Setup(r => r.Add(entity)).Returns(21);

            // Act
            int resultId = _service.Reserve(dto);

            // Assert
            Assert.Equal(21, resultId);
            _reserveRepoMock.Verify(r => r.Add(entity), Times.Once);
        }

        //[Fact]
        //public void Delete_ReturnsFalse_WhenReservationNotFound()
        //{
        //    // Arrange
        //    int resId = 99;
        //    _reserveRepoMock.Setup(r => r.GetById(resId)).Returns((ReserveEntity)null);

        //    // Act
        //    bool result = _service.Delete(resId);

        //    // Assert
        //    Assert.False(result);
        //    _reserveRepoMock.Verify(r => r.GetById(resId), Times.Once);
        //    _reserveRepoMock.Verify(r => r.Delete(It.IsAny<int>()), Times.Never);
        //}

        //[Fact]
        //public void Delete_RemovesReservation_WhenFound()
        //{
        //    // Arrange
        //    int resId = 5;
        //    var resEntity = new ReserveEntity { RID = resId, UID = 1, ISBN = "X" };
        //    _reserveRepoMock.Setup(r => r.GetById(resId)).Returns(resEntity);
        //    _reserveRepoMock.Setup(r => r.Delete(resId)).Returns(true);

        //    // Act
        //    bool result = _service.Delete(resId);

        //    // Assert
        //    Assert.True(result);
        //    _reserveRepoMock.Verify(r => r.Delete(resId), Times.Once);
        //}

        [Fact]
        public void GetAllByUser_ReturnsReservationsForUser()
        {
            int userId = 3;
            var table = new DataTable();
            _reserveRepoMock.Setup(r => r.GetAllByUserId(userId)).Returns(table);
            var result = _service.GetAllByUserId(userId);
            Assert.Same(table, result);
            _reserveRepoMock.Verify(r => r.GetAllByUserId(userId), Times.Once);
        }
    }
}
