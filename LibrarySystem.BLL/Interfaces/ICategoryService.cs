using LibrarySystem.BLL.DTOs;
using System.Collections.Generic;

namespace LibrarySystem.BLL.Interfaces
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
