using LibrarySystem.DAL.DataSets.CategoryDataSetTableAdapters;
using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Interfaces;
using System.Collections.Generic;
namespace LibrarySystem.DAL.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        private readonly TabCategoryTableAdapter tableAdapter = new TabCategoryTableAdapter();

        public int Add(CategoryEntity category)
        {
            var id = tableAdapter.InsertCustom(category.CategoryName);
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
