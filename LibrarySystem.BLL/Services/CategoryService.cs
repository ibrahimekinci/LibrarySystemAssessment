using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.Exceptions;
using LibrarySystem.Abstractions.Services;
using LibrarySystem.BLL.Services;
using LibrarySystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibrarySystem.BLL.Services
{
    public class CategoryService : BaseService, ICategoryService
    {
        public List<CategoryViewDto> GetAll()
        {
            var list = CategoryRepository.GetAll();
            return Mapper.Map<List<CategoryViewDto>>(list);
        }
        public CategoryViewDto GetById(int id)
        {
            var entity = CategoryRepository.GetById(id);
            return Mapper.Map<CategoryViewDto>(entity);
        }
        public int Add(CategoryCreateDto category)
        {
            var categories = CategoryRepository.GetAll();
            if (categories != null && categories.Count > 0)
            {
                bool categoryExists = categories.Any(x =>
                    String.Compare(x.CategoryName, category.CategoryName, StringComparison.OrdinalIgnoreCase) == 0);

                if (categoryExists)
                {
                    throw new ConflictException("Category was already added.");
                }
            }

            var entity = Mapper.Map<CategoryEntity>(category);
            return CategoryRepository.Add(entity);
        }

        public bool Update(CategoryUpdateDto category)
        {
            var entity = Mapper.Map<CategoryEntity>(category);
            return CategoryRepository.Update(entity);
        }

        public bool Delete(int categoryId)
        {
            return CategoryRepository.Delete(categoryId);
        }
    }
}
