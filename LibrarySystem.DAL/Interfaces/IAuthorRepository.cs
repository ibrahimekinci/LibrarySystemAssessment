using LibrarySystem.DAL.DTOs;
using LibrarySystem.DAL.Entities;
using System.Collections.Generic;

namespace LibrarySystem.DAL.Interfaces
{
    public interface IAuthorRepository
    {
        PagedResultDto<List<AuthorEntity>> GetAllPaged(PagedRequestDto request);
        int Add(AuthorEntity author);
        void Delete(int aid);
    }
}
