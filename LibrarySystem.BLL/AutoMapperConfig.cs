using AutoMapper;
using LibrarySystem.Abstractions.DTOs;
using LibrarySystem.Domain.Entities;

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
                cfg.CreateMap<BorrowViewDto, BorrowEntity>().ReverseMap();
                cfg.CreateMap<BookViewDto, BookEntity>().ReverseMap();
                cfg.CreateMap<CategoryViewDto, CategoryEntity>().ReverseMap();
                cfg.CreateMap<LanguageViewDto, LanguageEntity>().ReverseMap();
                cfg.CreateMap<ReserveViewDto, ReserveEntity>().ReverseMap();
                cfg.CreateMap<UserViewDto, UserEntity>().ReverseMap();
                cfg.CreateMap<AuthenticatedUserDto, UserEntity>().ReverseMap();

                cfg.CreateMap<AuthorCreateDto, AuthorEntity>();
                cfg.CreateMap<BorrowCreateDto, BorrowEntity>();
                cfg.CreateMap<BookDto, BookEntity>();
                cfg.CreateMap<CategoryCreateDto, CategoryEntity>();
                cfg.CreateMap<LanguageCreateDto, LanguageEntity>();
                cfg.CreateMap<ReserveCreateDto, ReserveEntity>();
                cfg.CreateMap<UserCreateDto, UserEntity>();

                cfg.CreateMap<AuthorUpdateDto, AuthorEntity>();
                cfg.CreateMap<BorrowReturnDto, BorrowEntity>();
                cfg.CreateMap<CategoryUpdateDto, CategoryEntity>();
                cfg.CreateMap<LanguageUpdateDto, LanguageEntity>();
                cfg.CreateMap<ReserveUpdateDto, ReserveEntity>();
                cfg.CreateMap<UserUpdateDto, UserEntity>();
            });
            //config.AssertConfigurationIsValid();
            _mapper = config.CreateMapper();
        }
    }
}