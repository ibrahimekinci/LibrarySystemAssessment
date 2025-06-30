using System.Data;
using LibrarySystem.DAL.DTOs;
using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Interfaces;
using LibrarySystem.DAL.DataSets.AuthorDataSetTableAdapters;
using System.Linq;
using System.Collections.Generic;

namespace LibrarySystem.DAL.Repositories
{
    public class AuthorRepository : BaseRepository, IAuthorRepository
    {
        private readonly TabAuthorTableAdapter _adapter = new TabAuthorTableAdapter();
        public PagedResultDto<List<AuthorEntity>> GetAllPaged(PagedRequestDto request)
        {
            var table = _adapter.GetData();
            var result = new PagedResultDto<List<AuthorEntity>>
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
                result.Items = Mapper.Map<List<AuthorEntity>>(pagedTable);
            }

            if (result.Items == null)
                result.Items = new List<AuthorEntity>();


            return result;
        }
        public int Add(AuthorEntity author)
        {
            return _adapter.Insert(author.AuthorName);
        }

        public void Delete(int aid)
        {
            _adapter.DeleteById(aid);
        }
    }
}
