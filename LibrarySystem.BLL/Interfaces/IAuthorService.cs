using LibrarySystem.BLL.DTOs;
using System.Collections.Generic;

namespace LibrarySystem.BLL.Interfaces
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
