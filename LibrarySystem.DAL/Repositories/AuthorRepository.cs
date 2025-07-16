using LibrarySystem.DAL.DataSets.AuthorDataSetTableAdapters;
using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Interfaces;
using System.Collections.Generic;
namespace LibrarySystem.DAL.Repositories
{
    public class AuthorRepository : BaseRepository, IAuthorRepository
    {
        private readonly TabAuthorTableAdapter tableAdapter = new TabAuthorTableAdapter();

        public int Add(AuthorEntity author)
        {
            var id = tableAdapter.InsertCustom(author.AuthorName);
            return id;
        }

        public bool Delete(int aid)
        {
            return tableAdapter.DeleteById(aid) > 0;
        }

        public List<AuthorEntity> GetAll()
        {
            var table = tableAdapter.GetData();
            var result = Mapper.Map<List<AuthorEntity>>(table) ?? new List<AuthorEntity>();
            return result;
        }

        public bool Update(AuthorEntity author)
        {
            return tableAdapter.UpdateById(author.AuthorName, author.AID) > 0;
        }
    }
}
