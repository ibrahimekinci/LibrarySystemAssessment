using AutoMapper;
using LibrarySystem.BLL.DTOs;
using LibrarySystem.BLL.Interfaces;
using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Interfaces;
using LibrarySystem.DAL.Repositories;
using System.Collections.Generic;

namespace LibrarySystem.BLL.Services
{
    public class MasterDataService : BaseService, IMasterDataService
    {
        ICategoryRepository categoryRepository = new CategoryRepository();
        public int AddAuthor(AuthorCreateDto author)
        {
            throw new System.NotImplementedException();
        }

        public int AddCategory(CategoryCreateDto category)
        {
            throw new System.NotImplementedException();
        }

        public int AddLanguage(LanguageCreateDto language)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteAuthor(int authorId)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteCategory(int categoryId)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteLanguage(int languageId)
        {
            throw new System.NotImplementedException();
        }

        public List<AuthorViewDto> GetAllAuthors()
        {
            throw new System.NotImplementedException();
        }


        public List<List<CategoryViewDto>> GetAllCategories()
        {
            throw new System.NotImplementedException();
        }

        public List<LanguageViewDto> GetAllLanguages()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateAuthor(AuthorUpdateDto author)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCategory(CategoryUpdateDto category)
        {
            throw new System.NotImplementedException();
        }

        public void UpdateLanguage(LanguageUpdateDto language)
        {
            throw new System.NotImplementedException();
        }
    }
}
