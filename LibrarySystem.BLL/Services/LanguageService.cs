using LibrarySystem.BLL.Interfaces;
using LibrarySystem.BLL.DTOs;
using LibrarySystem.BLL.Services;
using LibrarySystem.DAL.Entities;
using System.Collections.Generic;

namespace LibrarySystem.BLL.Services
{
    public class LanguageService : BaseService, ILanguageService
    {
        public List<LanguageViewDto> GetAllLanguages()
        {
            var list = LanguageRepository.GetAll();
            return Mapper.Map<List<LanguageViewDto>>(list);
        }
        public LanguageViewDto GetById(int id)
        {
            var entity = LanguageRepository.GetById(id);
            return Mapper.Map<LanguageViewDto>(entity);
        }
        public int AddLanguage(LanguageCreateDto language)
        {
            var entity = Mapper.Map<LanguageEntity>(language);
            return LanguageRepository.Add(entity);
        }

        public bool UpdateLanguage(LanguageUpdateDto language)
        {
            var entity = Mapper.Map<LanguageEntity>(language);
            return LanguageRepository.Update(entity);
        }

        public bool DeleteLanguage(int languageId)
        {
            return LanguageRepository.Delete(languageId);
        }
    }
}
