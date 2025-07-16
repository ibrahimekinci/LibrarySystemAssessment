using LibrarySystem.DAL.DataSets.AuthorDataSetTableAdapters;
using LibrarySystem.DAL.Entities;
using LibrarySystem.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
namespace LibrarySystem.DAL.Repositories
{
    public class AuthorRepository : BaseRepository, IAuthorRepository
    {
        private readonly TabAuthorTableAdapter tableAdapter = new TabAuthorTableAdapter();

        public int Add(AuthorEntity author)
        {
            var effectedDbRows = Convert.ToInt32(tableAdapter.InsertCustom(author.AuthorName));
            if (effectedDbRows <= 0)
                return 0;

            var id = Convert.ToInt32(tableAdapter.GetLastId());
            return id;
        }

        public bool Delete(int aid)
        {
            return tableAdapter.DeleteById(aid) > 0;
        }

        public List<AuthorEntity> GetAll()
        {
            var table = tableAdapter.GetData();
            var result = new List<AuthorEntity>();
            foreach (DataRow row in table.Rows)
            {
                var entity = AutoMapperConfig.Mapper.Map<AuthorEntity>(row);
                result.Add(entity);
            }

            //result = Mapper.Map<List<AuthorEntity>>(table);
            return result;
        }

        public bool Update(AuthorEntity author)
        {
            return tableAdapter.UpdateById(author.AuthorName, author.AID) > 0;
        }
    }
}
