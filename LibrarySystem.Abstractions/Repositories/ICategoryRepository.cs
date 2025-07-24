using LibrarySystem.Domain.Entities;
using System.Collections.Generic;

namespace LibrarySystem.Abstractions.Repositories
{
    public interface ICategoryRepository
    {
        List<CategoryEntity> GetAll();
        CategoryEntity GetById(int cid);
        int Add(CategoryEntity category);
        bool Update(CategoryEntity category);
        bool Delete(int cid);
    }
}
