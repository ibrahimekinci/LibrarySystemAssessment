using System;
using System.Data;
using LibrarySystem.DAL.DataSets;
using LibrarySystem.DAL.DTOs;
using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;

namespace LibrarySystem.DAL.Repositories
{
    public class ReserveRepository : BaseRepository, IReserveRepository
    {
        public int Add(ReserveEntity reserve)
        {
            throw new NotImplementedException();
        }

        public PagedResultDto<List<ReserveEntity>> GetByUserPaged(int uid, PagedRequestDto request)
        {
            throw new NotImplementedException();
        }
    }
}
