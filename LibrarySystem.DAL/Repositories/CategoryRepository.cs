using LibrarySystem.DAL.DataSets.CategoryDataSetTableAdapters;
using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Interfaces;
using System;
using System.Collections.Generic;
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
            return tableAdapter.DeleteById(cid) > 0;
        }

        public List<CategoryEntity> GetAll()
        {
            var table = tableAdapter.GetData();
            var result = Mapper.Map<List<CategoryEntity>>(table) ?? new List<CategoryEntity>();
            return result;
        }

        public bool Update(CategoryEntity category)
        {
            return tableAdapter.UpdateById(category.CategoryName, category.CID) > 0;
        }
    }
}
