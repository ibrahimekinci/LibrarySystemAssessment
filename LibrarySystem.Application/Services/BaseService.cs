using AutoMapper;

namespace LibrarySystem.BLL.Services
{
    public abstract class BaseService
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
