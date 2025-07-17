using LibrarySystem.DAL.DataSets.LanguageDataSetTableAdapters;
using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Helpers;
using LibrarySystem.DAL.Interfaces;
using System;
using System.Collections.Generic;

namespace LibrarySystem.DAL.Repositories
{
    public class LanguageRepository : BaseRepository, ILanguageRepository
    {
        private readonly TabLanguageTableAdapter tableAdapter = new TabLanguageTableAdapter();

        public int Add(LanguageEntity language)
        {
            var effectedDbRows = tableAdapter.InsertCustom(language.LanguageName);
            if (effectedDbRows <= 0)
                return 0;

            var id = Convert.ToInt32(tableAdapter.GetLastId());
            return id;
        }

        public bool Delete(int lid)
        {
            return 0 < tableAdapter.DeleteById(lid);
        }

        public List<LanguageEntity> GetAll()
        {
            return tableAdapter.GetData().ToList<LanguageEntity>();
        }

        public bool Update(LanguageEntity language)
        {
            return 0 < tableAdapter.UpdateById(language.LanguageName, language.LID);
        }
    }
}
