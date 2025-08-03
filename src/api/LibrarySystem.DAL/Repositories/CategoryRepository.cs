using LibrarySystem.DAL.DataSets.CategoryDataSetTableAdapters;
using LibrarySystem.Domain.Entities;
using LibrarySystem.DAL.Helpers;
using LibrarySystem.Abstractions.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
namespace LibrarySystem.DAL.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        #region TableAdapter Properties
        private TabCategoryTableAdapter _tabCategoryTableAdapter;
        private TabCategoryTableAdapter TabCategoryTableAdapter
        {
            get
            {
                if (_tabCategoryTableAdapter == null)
                {
                    _tabCategoryTableAdapter = new TabCategoryTableAdapter();
                    _tabCategoryTableAdapter.ApplyGlobalConfiguration();
                }
                return _tabCategoryTableAdapter;
            }
        }

        #endregion
        public CategoryEntity GetById(int id)
        {
            var table = TabCategoryTableAdapter.GetById(id);
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<CategoryEntity>().FirstOrDefault();
        }
        public int Add(CategoryEntity category)
        {
            var effectedDbRows = TabCategoryTableAdapter.InsertCustom(category.CategoryName);
            if (effectedDbRows <= 0)
                return 0;

            var id = Convert.ToInt32(TabCategoryTableAdapter.GetLastId());
            return id;
        }

        public bool Delete(int cid)
        {
            return 0 < TabCategoryTableAdapter.DeleteById(cid);
        }

        public List<CategoryEntity> GetAll()
        {
            var table = TabCategoryTableAdapter.GetData();
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<CategoryEntity>();
        }

        public bool Update(CategoryEntity category)
        {
            return 0 < TabCategoryTableAdapter.UpdateById(category.CategoryName, category.CID);
        }
    }
}
