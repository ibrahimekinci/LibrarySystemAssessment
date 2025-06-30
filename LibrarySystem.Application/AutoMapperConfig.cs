using AutoMapper;
using LibrarySystem.BLL.DTOs;
using LibrarySystem.DAL.Entities;
namespace LibrarySystem.BLL
{
    public static class AutoMapperConfig
    {
        private static IMapper _mapper;

        public static IMapper Mapper
        {
            get
            {
                if (_mapper == null)
                {
                    Initialize();
                }
                return _mapper;
            }
        }

        public static void Initialize()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<AuthorViewDto, AuthorEntity>().ReverseMap();
                cfg.CreateMap<BarrowViewDto, BarrowEntity>().ReverseMap();
                cfg.CreateMap<BookViewDto, BookEntity>().ReverseMap();
                cfg.CreateMap<CategoryViewDto, CategoryEntity>().ReverseMap();
                cfg.CreateMap<LanguageViewDto, LanguageEntity>().ReverseMap();
                cfg.CreateMap<ReserveViewDto, ReserveEntity>().ReverseMap();
                cfg.CreateMap<UserViewDto, UserEntity>().ReverseMap();

                cfg.CreateMap<AuthorCreateDto, AuthorEntity>();
                cfg.CreateMap<BarrowCreateDto, BarrowEntity>();
                cfg.CreateMap<BookDto, BookEntity>();
                cfg.CreateMap<CategoryCreateDto, CategoryEntity>();
                cfg.CreateMap<LanguageCreateDto, LanguageEntity>();
                cfg.CreateMap<ReserveCreateDto, ReserveEntity>();
                cfg.CreateMap<UserCreateDto, UserEntity>();

                cfg.CreateMap<AuthorUpdateDto, AuthorEntity>();
                cfg.CreateMap<BarrowUpdateDto, BarrowEntity>();
                cfg.CreateMap<CategoryUpdateDto, CategoryEntity>();
                cfg.CreateMap<LanguageUpdateDto, LanguageEntity>();
                cfg.CreateMap<ReserveUpdateDto, ReserveEntity>();
                cfg.CreateMap<UserUpdateDto, UserEntity>();

                cfg.CreateMap<BookSearchCriteriaDto, DAL.DTOs.BookSearchCriteriaDto>();
                cfg.CreateMap<PagedRequestDto, DAL.DTOs.PagedRequestDto>().ReverseMap();
                cfg.CreateMap(typeof(DAL.DTOs.PagedResultDto<>), typeof(PagedResultDto<>))
         .ForMember("Items", opt => opt.MapFrom("Items"))
         .ForMember("TotalCount", opt => opt.MapFrom("TotalCount"))
         .ForMember("PageNumber", opt => opt.MapFrom("PageNumber"))
         .ForMember("PageSize", opt => opt.MapFrom("PageSize"));


            });
            //config.AssertConfigurationIsValid();
            _mapper = config.CreateMapper();
        }
    }
}