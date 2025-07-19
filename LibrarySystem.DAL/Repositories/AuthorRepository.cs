using LibrarySystem.DAL.DataSets.AuthorDataSetTableAdapters;
using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Helpers;
using LibrarySystem.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace LibrarySystem.DAL.Repositories
{
    public class AuthorRepository : BaseRepository, IAuthorRepository
    {
        private readonly TabAuthorTableAdapter tableAdapter = new TabAuthorTableAdapter();

        public int Add(AuthorEntity author)
        {
            var effectedDbRows = Convert.ToInt32(tableAdapter.InsertCustom(author.AuthorName));
            if (effectedDbRows <= 0)
                return 0;

            var id = Convert.ToInt32(tableAdapter.GetLastId());
            return id;
        }

        public bool Delete(int aid)
        {
            return tableAdapter.DeleteById(aid) > 0;
        }

        public List<AuthorEntity> GetAll()
        {
            var table = tableAdapter.GetData();
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<AuthorEntity>();
        }

        public AuthorEntity GetById(int aid)
        {
            var table = tableAdapter.GetById(aid);
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<AuthorEntity>().FirstOrDefault();

        }

        public bool Update(AuthorEntity author)
        {
            return tableAdapter.UpdateById(author.AuthorName, author.AID) > 0;
        }
    }
}
