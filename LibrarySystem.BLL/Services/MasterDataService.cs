using LibrarySystem.BLL.DTOs;
using LibrarySystem.BLL.Interfaces;
using LibrarySystem.DAL.Entities;
using System.Collections.Generic;

namespace LibrarySystem.BLL.Services
{
    public class MasterDataService : BaseService, IMasterDataService
    {
        public MasterDataService()
        {
        }

        // ----------- AUTHORS -----------

        public List<AuthorViewDto> GetAllAuthors()
        {
            var list = AuthorRepository.GetAll();
            return Mapper.Map<List<AuthorViewDto>>(list);
        }

        public int AddAuthor(AuthorCreateDto author)
        {
            var entity = Mapper.Map<AuthorEntity>(author);
            return AuthorRepository.Add(entity);
        }

        public bool UpdateAuthor(AuthorUpdateDto author)
        {
            var entity = Mapper.Map<AuthorEntity>(author);
            return AuthorRepository.Update(entity);
        }

        public bool DeleteAuthor(int authorId)
        {
            return AuthorRepository.Delete(authorId);
        }

        // ----------- CATEGORIES -----------

        public List<CategoryViewDto> GetAllCategories()
        {
            var list = CategoryRepository.GetAll();
            return Mapper.Map<List<CategoryViewDto>>(list);
        }

        public int AddCategory(CategoryCreateDto category)
        {
            var entity = Mapper.Map<CategoryEntity>(category);
            return CategoryRepository.Add(entity);
        }

        public bool UpdateCategory(CategoryUpdateDto category)
        {
            var entity = Mapper.Map<CategoryEntity>(category);
            return CategoryRepository.Update(entity);
        }

        public bool DeleteCategory(int categoryId)
        {
            return CategoryRepository.Delete(categoryId);
        }

        // ----------- LANGUAGES -----------

        public List<LanguageViewDto> GetAllLanguages()
        {
            var list = LanguageRepository.GetAll();
            return Mapper.Map<List<LanguageViewDto>>(list);
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
