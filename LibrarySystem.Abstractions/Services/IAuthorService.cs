using LibrarySystem.Abstractions.DTOs;
using System.Collections.Generic;

namespace LibrarySystem.Abstractions.Services
{
    public interface IAuthorService
    {
        List<AuthorViewDto> GetAll();
        AuthorViewDto GetById(int id);
        int Add(AuthorCreateDto author);
        bool Update(AuthorUpdateDto author);
        bool Delete(int id);
    }
}
