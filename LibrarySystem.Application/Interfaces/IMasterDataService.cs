using LibrarySystem.BLL.DTOs;
using System.Collections.Generic;

namespace LibrarySystem.BLL.Interfaces
{
    public interface IMasterDataService
    {
        List<AuthorViewDto> GetAllAuthors();
        List<List<CategoryViewDto>> GetAllCategories();
        List<LanguageViewDto> GetAllLanguages();

        int AddAuthor(AuthorCreateDto author);
        int AddCategory(CategoryCreateDto category);
        int AddLanguage(LanguageCreateDto language);

        void UpdateAuthor(AuthorUpdateDto author);
        void UpdateCategory(CategoryUpdateDto category);
        void UpdateLanguage(LanguageUpdateDto language);

        void DeleteAuthor(int authorId);
        void DeleteCategory(int categoryId);
        void DeleteLanguage(int languageId);
    }
}
