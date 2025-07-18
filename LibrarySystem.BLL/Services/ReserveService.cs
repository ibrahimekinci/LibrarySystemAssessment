using LibrarySystem.BLL.DTOs;
using LibrarySystem.BLL.Interfaces;
using LibrarySystem.DAL.Entities;
using System.Collections.Generic;

namespace LibrarySystem.BLL.Services
{
    public class ReserveService : BaseService, IReserveService
    {
        public ReserveService()
        {
        }

        public int ReserveBook(ReserveCreateDto reserveRecordDto)
        {
            var entity = Mapper.Map<ReserveEntity>(reserveRecordDto);
            return ReserveRepository.Add(entity);
        }

        public bool UpdateBookReservation(ReserveUpdateDto reserveRecordDto)
        {
            // Simple way to treat it: delete + add pattern since there's no update in repo
            var deleteSuccess = ReserveRepository.Delete(reserveRecordDto.RID);
            if (!deleteSuccess)
                return false;

            var newEntity = Mapper.Map<ReserveEntity>(reserveRecordDto);
            return ReserveRepository.Add(newEntity) > 0;
        }

        public List<ReserveViewDto> GetReservationsByUser(int userId)
        {
            var data = ReserveRepository.GetByUserId(userId);
            return data == null ? new List<ReserveViewDto>() : Mapper.Map<List<ReserveViewDto>>(data);
        }

        public bool CancelReservation(int reservationId)
        {
            return ReserveRepository.Delete(reservationId);
        }
    }
}
