using LibrarySystem.DAL.DTOs;
using LibrarySystem.DAL.Entities;
using System.Collections.Generic;

namespace LibrarySystem.DAL.Interfaces
{
    public interface ILanguageRepository
    {
        List<LanguageEntity> GetAll();
        LanguageEntity GetById(int lid);
        int Add(LanguageEntity language);
        bool Update(LanguageEntity language);
        bool Delete(int lid);
    }
}
