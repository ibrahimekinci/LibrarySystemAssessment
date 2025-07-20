using LibrarySystem.BLL.DTOs;
using System.Collections.Generic;

namespace LibrarySystem.BLL.Interfaces
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
