using LibrarySystem.DAL.Entities;
using System.Collections.Generic;

namespace LibrarySystem.DAL.Interfaces
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
