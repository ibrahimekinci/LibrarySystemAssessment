using AutoMapper;
using LibrarySystem.Abstractions.DTOs;

namespace LibrarySystem.App.Helpers
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
                cfg.CreateMap<AuditService.AuditLogDto, AuditLogDto>().ReverseMap();
                cfg.CreateMap<AuthorService.AuthorCreateDto, AuthorCreateDto>().ReverseMap();
                cfg.CreateMap<AuthorService.AuthorUpdateDto, AuthorUpdateDto>().ReverseMap();
                cfg.CreateMap<AuthorService.AuthorViewDto, AuthorViewDto>().ReverseMap();
                cfg.CreateMap<AuthService.AuthenticatedUserDto, AuthenticatedUserDto>().ReverseMap();
                cfg.CreateMap<BookLoanService.BorrowCreateDto, BorrowCreateDto>().ReverseMap();
                cfg.CreateMap<BookLoanService.BorrowReturnDto, BorrowReturnDto>().ReverseMap();
                cfg.CreateMap<BookLoanService.BorrowViewDto, BorrowViewDto>().ReverseMap();
                cfg.CreateMap<BookReservationService.ReserveCreateDto, ReserveCreateDto>().ReverseMap();
                cfg.CreateMap<BookReservationService.ReserveUpdateDto, ReserveUpdateDto>().ReverseMap();
                cfg.CreateMap<BookReservationService.ReserveViewDto, ReserveViewDto>().ReverseMap();
                cfg.CreateMap<BookService.BookDto, BookDto>().ReverseMap();
                cfg.CreateMap<BookService.BookSearchCriteriaDto, BookSearchCriteriaDto>().ReverseMap();
                //cfg.CreateMap<BookService.BookUpdateDto, BookUpdateDto>().ReverseMap();
                cfg.CreateMap<BookService.BookViewDto, BookViewDto>().ReverseMap();
                cfg.CreateMap<CategoryService.CategoryCreateDto, CategoryCreateDto>().ReverseMap();
                cfg.CreateMap<CategoryService.CategoryUpdateDto, CategoryUpdateDto>().ReverseMap();
                cfg.CreateMap<CategoryService.CategoryViewDto, CategoryViewDto>().ReverseMap();
                cfg.CreateMap<LanguageService.LanguageCreateDto, LanguageCreateDto>().ReverseMap();
                cfg.CreateMap<LanguageService.LanguageUpdateDto, LanguageUpdateDto>().ReverseMap();
                cfg.CreateMap<LanguageService.LanguageViewDto, LanguageViewDto>().ReverseMap();
                cfg.CreateMap<UserService.UserCreateDto, UserCreateDto>().ReverseMap();
                cfg.CreateMap<UserService.UserPasswordUpdateDto, UserPasswordUpdateDto>().ReverseMap();
                cfg.CreateMap<UserService.UserUpdateDto, UserUpdateDto>().ReverseMap();
                cfg.CreateMap<UserService.UserViewDto, UserViewDto>().ReverseMap();
            });
            //config.AssertConfigurationIsValid();
            _mapper = config.CreateMapper();
        }
    }
}