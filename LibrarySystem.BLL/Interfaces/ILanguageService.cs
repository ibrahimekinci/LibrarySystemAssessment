using LibrarySystem.BLL.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibrarySystem.BLL.Interfaces
{
    public interface ILanguageService
    {
        List<LanguageViewDto> GetAllLanguages();
        LanguageViewDto GetById(int id);
        int AddLanguage(LanguageCreateDto language);
        bool UpdateLanguage(LanguageUpdateDto language);
        bool DeleteLanguage(int languageId);
    }
}
