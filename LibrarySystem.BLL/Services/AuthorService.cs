using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Abstractions.Services;
using LibrarySystem.Domain.Entities;
using System.Collections.Generic;

namespace LibrarySystem.BLL.Services
{
    public class AuthorService : BaseService, IAuthorService
    {
        public int Add(AuthorCreateDto author)
        {
            var entity = Mapper.Map<AuthorEntity>(author);
            return AuthorRepository.Add(entity);
        }

        public bool Update(AuthorUpdateDto author)
        {
            var entity = Mapper.Map<AuthorEntity>(author);
            return AuthorRepository.Update(entity);
        }

        public bool Delete(int authorId)
        {
            return AuthorRepository.Delete(authorId);
        }

        public List<AuthorViewDto> GetAll()
        {
            var list = AuthorRepository.GetAll();
            return Mapper.Map<List<AuthorViewDto>>(list);
        }

        public AuthorViewDto GetById(int id)
        {
            var entity = AuthorRepository.GetById(id);
            return Mapper.Map<AuthorViewDto>(entity);
        }
    }
}
