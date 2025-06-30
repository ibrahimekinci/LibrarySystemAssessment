using LibrarySystem.DAL.DTOs;
using LibrarySystem.DAL.Entities;
using System.Collections.Generic;
using System.Data;

namespace LibrarySystem.DAL.Interfaces
{
    public interface ILanguageRepository
    {
        PagedResultDto<List<LanguageEntity>> GetAllPaged(PagedRequestDto request);
        int Add(LanguageEntity language);
        void Delete(int lid);
    }
}
