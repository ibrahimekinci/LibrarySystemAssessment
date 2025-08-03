using LibrarySystem.DAL.DataSets.AuthorDataSetTableAdapters;
using LibrarySystem.Domain.Entities;
using LibrarySystem.DAL.Helpers;
using LibrarySystem.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace LibrarySystem.DAL.Repositories
{
    public class AuthorRepository : BaseRepository, IAuthorRepository
    {
        #region TableAdapter Properties
        private TabAuthorTableAdapter _tabAuthorTableAdapter;

        private TabAuthorTableAdapter TabAuthorTableAdapter
        {
            get
            {
                if (_tabAuthorTableAdapter == null)
                {
                    _tabAuthorTableAdapter = new TabAuthorTableAdapter();
                    _tabAuthorTableAdapter.ApplyGlobalConfiguration();
                }
                return _tabAuthorTableAdapter;
            }
        }
        #endregion

        public int Add(AuthorEntity author)
        {
            var effectedDbRows = Convert.ToInt32(TabAuthorTableAdapter.InsertCustom(author.AuthorName));
            if (effectedDbRows <= 0)
                return 0;

            var id = Convert.ToInt32(TabAuthorTableAdapter.GetLastId());
            return id;
        }

        public bool Delete(int aid)
        {
            return TabAuthorTableAdapter.DeleteById(aid) > 0;
        }

        public List<AuthorEntity> GetAll()
        {
            var table = TabAuthorTableAdapter.GetData();
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<AuthorEntity>();
        }

        public AuthorEntity GetById(int aid)
        {
            var table = TabAuthorTableAdapter.GetById(aid);
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<AuthorEntity>().FirstOrDefault();

        }

        public bool Update(AuthorEntity author)
        {
            return TabAuthorTableAdapter.UpdateById(author.AuthorName, author.AID) > 0;
        }
    }
}
