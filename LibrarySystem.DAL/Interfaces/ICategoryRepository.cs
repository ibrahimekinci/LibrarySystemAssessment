using LibrarySystem.DAL.DTOs;
using LibrarySystem.DAL.Entities;
using System.Collections.Generic;

namespace LibrarySystem.DAL.Interfaces
{
    public interface ICategoryRepository
    {
        //PagedResultDto<List<CategoryEntity>> GetAllPaged(PagedRequestDto request);
        List<CategoryEntity> GetAll();
        int Add(CategoryEntity category);
        bool Update(CategoryEntity category);
        bool Delete(int cid);
    }
}
