using LibrarySystem.Application.DTOs;
using System.Collections.Generic;

namespace LibrarySystem.Application.Interfaces
{
    public interface IMasterDataService
    {
        PagedResultDataTableDto<AuthorViewDto> GetAllAuthors(PagedRequestDto pagedRequestDto);
        PagedResultDataTableDto<CategoryViewDto> GetAllCategories(PagedRequestDto pagedRequestDto);
        PagedResultDataTableDto<LanguageViewDto> GetAllLanguages(PagedRequestDto pagedRequestDto);

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
