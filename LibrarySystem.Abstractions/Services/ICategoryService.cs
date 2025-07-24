using LibrarySystem.Abstractions.DTOs;
using System.Collections.Generic;

namespace LibrarySystem.Abstractions.Services
{
    public interface ICategoryService
    {
        List<CategoryViewDto> GetAll();
        CategoryViewDto GetById(int id);
        int Add(CategoryCreateDto category);
        bool Update(CategoryUpdateDto category);
        bool Delete(int categoryId);
    }
}
