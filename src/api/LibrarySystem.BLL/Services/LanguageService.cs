using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.Exceptions;
using LibrarySystem.Abstractions.Services;
using LibrarySystem.BLL.Services;
using LibrarySystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem.BLL.Services
{
    public class LanguageService : BaseService, ILanguageService
    {
        public List<LanguageViewDto> GetAll()
        {
            var list = LanguageRepository.GetAll();
            return Mapper.Map<List<LanguageViewDto>>(list);
        }
        public LanguageViewDto GetById(int id)
        {
            var entity = LanguageRepository.GetById(id);
            return Mapper.Map<LanguageViewDto>(entity);
        }
        public int Add(LanguageCreateDto language)
        {
            var languages = LanguageRepository.GetAll();
            if (languages != null && languages.Count > 0)
            {
                bool languageExists = languages.Any(existingLanguage =>
                    String.Compare(existingLanguage.LanguageName, language.LanguageName, StringComparison.OrdinalIgnoreCase) == 0);

                if (languageExists)
                {
                    throw new ConflictException("Language was already added.");
                }
            }

            var entity = Mapper.Map<LanguageEntity>(language);
            return LanguageRepository.Add(entity);
        }

        public bool Update(LanguageUpdateDto language)
        {
            var entity = Mapper.Map<LanguageEntity>(language);
            return LanguageRepository.Update(entity);
        }

        public bool Delete(int languageId)
        {
            return LanguageRepository.Delete(languageId);
        }
    }
}
