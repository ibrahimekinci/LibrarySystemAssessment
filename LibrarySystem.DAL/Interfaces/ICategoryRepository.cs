using LibrarySystem.DAL.DTOs;
using LibrarySystem.DAL.Entities;
using System.Collections.Generic;

namespace LibrarySystem.DAL.Interfaces
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
