using AutoMapper;

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
    }
}
