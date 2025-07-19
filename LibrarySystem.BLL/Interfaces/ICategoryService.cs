using LibrarySystem.BLL.DTOs;
using System.Collections.Generic;

namespace LibrarySystem.BLL.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryViewDto> GetAllCategories();
        CategoryViewDto GetById(int id);
        int AddCategory(CategoryCreateDto category);
        bool UpdateCategory(CategoryUpdateDto category);
        bool DeleteCategory(int categoryId);
    }
}
