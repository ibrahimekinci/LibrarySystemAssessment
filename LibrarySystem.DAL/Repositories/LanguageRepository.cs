using LibrarySystem.DAL.DataSets.LanguageDataSetTableAdapters;
using LibrarySystem.DAL.Entities;
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
            return tableAdapter.DeleteById(lid) > 0;
        }

        public List<LanguageEntity> GetAll()
        {
            var table = tableAdapter.GetData();
            var result = Mapper.Map<List<LanguageEntity>>(table) ?? new List<LanguageEntity>();
            return result;
        }

        public bool Update(LanguageEntity language)
        {
            return tableAdapter.UpdateById(language.LanguageName, language.LID) > 0;
        }
    }
}
