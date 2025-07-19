using LibrarySystem.BLL.Interfaces;
using LibrarySystem.BLL.DTOs;
using LibrarySystem.BLL.Services;
using LibrarySystem.DAL.Entities;
using System.Collections.Generic;

namespace LibrarySystem.BLL.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        public List<CategoryViewDto> GetAllCategories()
        {
            var list = CategoryRepository.GetAll();
            return Mapper.Map<List<CategoryViewDto>>(list);
        }
        public CategoryViewDto GetById(int id)
        {
            var entity = CategoryRepository.GetById(id);
            return Mapper.Map<CategoryViewDto>(entity);
        }
        public int AddCategory(CategoryCreateDto category)
        {
            var entity = Mapper.Map<CategoryEntity>(category);
            return CategoryRepository.Add(entity);
        }

        public bool UpdateCategory(CategoryUpdateDto category)
        {
            var entity = Mapper.Map<CategoryEntity>(category);
            return CategoryRepository.Update(entity);
        }

        public bool DeleteCategory(int categoryId)
        {
            return CategoryRepository.Delete(categoryId);
        }
    }
}
