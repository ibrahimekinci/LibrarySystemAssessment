using LibrarySystem.Abstractions.DTOs;
using System.Collections.Generic;

namespace LibrarySystem.Abstractions.Services
{
    public interface ILanguageService
    {
        List<LanguageViewDto> GetAll();
        LanguageViewDto GetById(int id);
        int Add(LanguageCreateDto language);
        bool Update(LanguageUpdateDto language);
        bool Delete(int languageId);
    }
}
