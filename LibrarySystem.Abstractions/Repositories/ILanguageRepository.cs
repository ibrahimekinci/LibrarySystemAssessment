using LibrarySystem.Domain.Entities;
using System.Collections.Generic;

namespace LibrarySystem.Abstractions.Repositories
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
