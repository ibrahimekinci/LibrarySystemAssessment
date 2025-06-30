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

        public PagedResultDto<AuthorViewDto> GetAllAuthors(PagedRequestDto pagedRequestDto)
        {
            throw new System.NotImplementedException();
        }

        public PagedResultDto<List<CategoryViewDto>> GetAllCategories(PagedRequestDto pagedRequestDto = null)
        {
         var repoDto= Mapper.Map<DAL.DTOs.PagedRequestDto>(pagedRequestDto ?? new PagedRequestDto());
            
            var resultEntities = categoryRepository.GetAllPaged(repoDto);
            var result = Mapper.Map<PagedResultDto<List<CategoryViewDto>>>(resultEntities);
            return result;
        }

        public PagedResultDto<LanguageViewDto> GetAllLanguages(PagedRequestDto pagedRequestDto)
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
