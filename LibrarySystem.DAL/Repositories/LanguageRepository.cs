using System.Data;
using LibrarySystem.DAL.DTOs;
using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Interfaces;
using System.Linq;
using System.Collections.Generic;
using System;
using LibrarySystem.DAL.DataSets.LanguageDataSetTableAdapters;

namespace LibrarySystem.DAL.Repositories
{
    public class LanguageRepository : BaseRepository, ILanguageRepository
    {
        private readonly TabLanguageTableAdapter _adapter = new TabLanguageTableAdapter();
        PagedResultDto<List<LanguageEntity>> ILanguageRepository.GetAllPaged(PagedRequestDto request)
        {
            var table = _adapter.GetData();
            var result = new PagedResultDto<List<LanguageEntity>>
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
                result.Items = Mapper.Map<List<LanguageEntity>>(pagedTable);
            }

            if (result.Items == null)
                result.Items = new List<LanguageEntity>();
            return result;
        }
        public int Add(LanguageEntity language)
        {
            throw new NotImplementedException();
        }

        public void Delete(int lid)
        {
            throw new NotImplementedException();
        }

    }
}
