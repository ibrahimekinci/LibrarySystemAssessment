using LibrarySystem.Application.DTOs;
using LibrarySystem.Application.Interfaces;

namespace LibrarySystem.Application.Services
{
    public class MasterDataService : IMasterDataService
    {
        public int AddAuthor(AuthorCreateDto author)
        {
            throw new System.NotImplementedException();
        }

        public int AddCategory(CategoryCreateDto category)
        {
            throw new System.NotImplementedException();
        }

        public int AddLanguage(LanguageCreateDto language)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteAuthor(int authorId)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCategory(int categoryId)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteLanguage(int languageId)
        {
            throw new System.NotImplementedException();
        }

        public PagedResultDataTableDto<AuthorViewDto> GetAllAuthors(PagedRequestDto pagedRequestDto)
        {
            throw new System.NotImplementedException();
        }

        public PagedResultDataTableDto<CategoryViewDto> GetAllCategories(PagedRequestDto pagedRequestDto)
        {
            throw new System.NotImplementedException();
        }

        public PagedResultDataTableDto<LanguageViewDto> GetAllLanguages(PagedRequestDto pagedRequestDto)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateAuthor(AuthorUpdateDto author)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCategory(CategoryUpdateDto category)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateLanguage(LanguageUpdateDto language)
        {
            throw new System.NotImplementedException();
        }
    }
}
