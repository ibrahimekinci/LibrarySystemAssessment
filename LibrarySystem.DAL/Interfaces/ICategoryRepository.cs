using LibrarySystem.DAL.DTOs;
using LibrarySystem.DAL.Entities;
using System.Collections.Generic;
using System.Data;

namespace LibrarySystem.DAL.Interfaces
{
    public interface ICategoryRepository
    {
        PagedResultDto<List<CategoryEntity>> GetAllPaged(PagedRequestDto request);
        int Add(CategoryEntity category);
        void Delete(int cid);
    }
}
