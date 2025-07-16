using AutoMapper;
using System;

namespace LibrarySystem.DAL.Repositories
{
    public abstract class BaseRepository
    {
        private static IMapper _mapper;

        public static IMapper Mapper
        {
            get
            {
                if (_mapper == null)
                {
                    _mapper = AutoMapperConfig.Mapper;
                }
                return _mapper;
            }
        }
        public static string formatDateForDb(DateTime date)
        {
            return date.ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
