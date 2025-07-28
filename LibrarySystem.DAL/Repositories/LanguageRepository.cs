using LibrarySystem.DAL.DataSets.LanguageDataSetTableAdapters;
using LibrarySystem.Domain.Entities;
using LibrarySystem.DAL.Helpers;
using LibrarySystem.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace LibrarySystem.DAL.Repositories
{
    public class LanguageRepository : BaseRepository, ILanguageRepository
    {
        #region TableAdapter Properties

        private TabLanguageTableAdapter _tabLanguageTableAdapter;
        private TabLanguageTableAdapter TabLanguageTableAdapter
        {
            get
            {
                if (_tabLanguageTableAdapter == null)
                {
                    _tabLanguageTableAdapter = new TabLanguageTableAdapter();
                    _tabLanguageTableAdapter.ApplyGlobalConfiguration();
                }
                return _tabLanguageTableAdapter;
            }
        }

        #endregion

        public LanguageEntity GetById(int id)
        {
            var table = TabLanguageTableAdapter.GetById(id);
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<LanguageEntity>().FirstOrDefault();
        }
        public int Add(LanguageEntity language)
        {
            var effectedDbRows = TabLanguageTableAdapter.InsertCustom(language.LanguageName);
            if (effectedDbRows <= 0)
                return 0;

            var id = Convert.ToInt32(TabLanguageTableAdapter.GetLastId());
            return id;
        }

        public bool Delete(int lid)
        {
            return 0 < TabLanguageTableAdapter.DeleteById(lid);
        }

        public List<LanguageEntity> GetAll()
        {
            var table = TabLanguageTableAdapter.GetData();
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<LanguageEntity>();
        }

        public bool Update(LanguageEntity language)
        {
            return 0 < TabLanguageTableAdapter.UpdateById(language.LanguageName, language.LID);
        }
    }
}
