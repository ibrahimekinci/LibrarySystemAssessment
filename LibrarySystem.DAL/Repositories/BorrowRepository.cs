using System;
using System.Data;
using LibrarySystem.DAL.DataSets;
using LibrarySystem.DAL.DTOs;
using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Interfaces;
using AutoMapper;
using System.Collections.Generic;
using LibrarySystem.DAL.DataSets.BarrowDataSetTableAdapters;

namespace LibrarySystem.DAL.Repositories
{
    public class BorrowRepository : BaseRepository, IBorrowRepository
    {
        private readonly TabBorrowTableAdapter _adapter = new TabBorrowTableAdapter();

        public int Add(BarrowEntity borrow)
        {
            throw new NotImplementedException();
        }

        public BarrowEntity GetById(int bid)
        {
            throw new NotImplementedException();
        }

        public PagedResultDto<List<BarrowEntity>> GetByUserPaged(int uid, PagedRequestDto request)
        {
            throw new NotImplementedException();
        }

        public void Return(int borrowId, DateTime actualReturnDate)
        {
            throw new NotImplementedException();
        }
    }
}
