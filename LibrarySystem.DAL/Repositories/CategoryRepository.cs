using LibrarySystem.DAL.DataSets.CategoryDataSetTableAdapters;
using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Helpers;
using LibrarySystem.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
namespace LibrarySystem.DAL.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        private readonly TabCategoryTableAdapter tableAdapter = new TabCategoryTableAdapter();

        public int Add(CategoryEntity category)
        {
            var effectedDbRows = tableAdapter.InsertCustom(category.CategoryName);
            if (effectedDbRows <= 0)
                return 0;

            var id = Convert.ToInt32(tableAdapter.GetLastId());
            return id;
        }

        public bool Delete(int cid)
        {
            return 0 < tableAdapter.DeleteById(cid);
        }

        public List<CategoryEntity> GetAll()
        {
            var table = tableAdapter.GetData();
            if (table == null || table.Rows.Count == 0)
                return null;
            return table.CopyToDataTable().ToList<CategoryEntity>();
        }

        public bool Update(CategoryEntity category)
        {
            return 0 < tableAdapter.UpdateById(category.CategoryName, category.CID);
        }
    }
}
