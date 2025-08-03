using LibrarySystem.Domain.Entities;
using System.Collections.Generic;

namespace LibrarySystem.Abstractions.Repositories
{
    public interface IAuthorRepository
    {
        List<AuthorEntity> GetAll();
        AuthorEntity GetById(int aID);
        int Add(AuthorEntity author);
        bool Delete(int aid);
        bool Update(AuthorEntity author);
    }
}
