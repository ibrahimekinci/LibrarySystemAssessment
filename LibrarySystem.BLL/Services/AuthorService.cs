using LibrarySystem.BLL.Interfaces;
using LibrarySystem.BLL.DTOs;
using LibrarySystem.BLL.Services;
using LibrarySystem.DAL.Entities;
using System.Collections.Generic;

namespace LibrarySystem.BLL.Services
{
    public class AuthorService : BaseService, IAuthorService
    {
        public int AddAuthor(AuthorCreateDto author)
        {
            var entity = Mapper.Map<AuthorEntity>(author);
            return AuthorRepository.Add(entity);
        }

        public bool UpdateAuthor(AuthorUpdateDto author)
        {
            var entity = Mapper.Map<AuthorEntity>(author);
            return AuthorRepository.Update(entity);
        }

        public bool DeleteAuthor(int authorId)
        {
            return AuthorRepository.Delete(authorId);
        }

        public List<AuthorViewDto> GetAllAuthors()
        {
            var list = AuthorRepository.GetAll();
            return Mapper.Map<List<AuthorViewDto>>(list);
        }

        public AuthorViewDto GetAuthorById(int id)
        {
            var entity = AuthorRepository.GetById(id);
            return Mapper.Map<AuthorViewDto>(entity);
        }
    }
}
