using System.Data;
using LibrarySystem.DAL.DTOs;
using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Interfaces;
using System.Linq;
using System.Collections.Generic;
using System;
using LibrarySystem.DAL.DataSets.CategoryDataSetTableAdapters;
namespace LibrarySystem.DAL.Repositories
{
    public class CategoryRepository : BaseRepository, ICategoryRepository
    {
        private readonly TabCategoryTableAdapter _adapter = new TabCategoryTableAdapter();

        public PagedResultDto<List<CategoryEntity>> GetAllPaged(PagedRequestDto request)
        {
            var table = _adapter.GetData();
            var result = new PagedResultDto<List<CategoryEntity>>
            {
                TotalCount = table.Rows.Count,
                PageNumber = request.PageNumber,
                PageSize = request.PageSize
            };

            if (result.TotalCount > 0 && result.PageSize > 0 && result.PageNumber > 0)
            {
                DataTable pagedTable = table.Clone();
                int skip = (request.PageNumber - 1) * request.PageSize;
                foreach (DataRow row in table.Rows.Cast<DataRow>().Skip(skip).Take(request.PageSize))
                    pagedTable.ImportRow(row);
                result.Items = Mapper.Map<List<CategoryEntity>>(pagedTable);
            }

            if (result.Items == null)
                result.Items = new List<CategoryEntity>();


            return result;
        }
        public int Add(CategoryEntity category)
        {
            throw new NotImplementedException();
        }

        public void Delete(int cid)
        {
            throw new NotImplementedException();
        }
    }
}
