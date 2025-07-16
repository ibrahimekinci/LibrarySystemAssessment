using LibrarySystem.DAL.DTOs;
using LibrarySystem.DAL.Entities;
using System.Collections.Generic;

namespace LibrarySystem.DAL.Interfaces
{
    public interface ILanguageRepository
    {
        //PagedResultDto<List<LanguageEntity>> GetAllPaged(PagedRequestDto request);
        List<LanguageEntity> GetAll();
        int Add(LanguageEntity language);
        bool Update(LanguageEntity language);
        bool Delete(int lid);
    }
}
