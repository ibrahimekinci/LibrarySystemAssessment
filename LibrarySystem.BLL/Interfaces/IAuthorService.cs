using LibrarySystem.BLL.DTOs;
using System.Collections.Generic;

namespace LibrarySystem.BLL.Interfaces
{
    public interface IAuthorService
    {
        List<AuthorViewDto> GetAllAuthors();
        AuthorViewDto GetAuthorById(int id);
        int AddAuthor(AuthorCreateDto author);
        bool UpdateAuthor(AuthorUpdateDto author);
        bool DeleteAuthor(int id);
    }
}
