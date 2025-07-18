using LibrarySystem.BLL.DTOs;
using System.Collections.Generic;

namespace LibrarySystem.BLL.Interfaces
{
    public interface IMasterDataService
    {
        List<AuthorViewDto> GetAllAuthors();
        List<CategoryViewDto> GetAllCategories();
        List<LanguageViewDto> GetAllLanguages();

        int AddAuthor(AuthorCreateDto author);
        int AddCategory(CategoryCreateDto category);
        int AddLanguage(LanguageCreateDto language);

        bool UpdateAuthor(AuthorUpdateDto author);
        bool UpdateCategory(CategoryUpdateDto category);
        bool UpdateLanguage(LanguageUpdateDto language);

        bool DeleteAuthor(int authorId);
        bool DeleteCategory(int categoryId);
        bool DeleteLanguage(int languageId);
    }
}
