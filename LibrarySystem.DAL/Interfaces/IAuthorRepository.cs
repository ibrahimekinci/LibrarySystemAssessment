using LibrarySystem.DAL.DTOs;
using LibrarySystem.DAL.Entities;
using System.Collections.Generic;

namespace LibrarySystem.DAL.Interfaces
{
    public interface IAuthorRepository
    {
        //PagedResultDto<List<AuthorEntity>> GetAllPaged(PagedRequestDto request);
        List<AuthorEntity> GetAll();
        int Add(AuthorEntity author);
        bool Delete(int aid);
        bool Update(AuthorEntity author);
    }
}
