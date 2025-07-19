using AutoMapper;
using LibrarySystem.DAL.Interfaces;
using LibrarySystem.DAL.Repositories;

namespace LibrarySystem.BLL.Services
{
    public abstract class BaseService
    {
        private static IMapper _mapper;
        private IBookRepository _bookRepository;
        private IUserRepository _userRepository;
        private IBookLoanRepository _bookLoanRepository;
        private IReserveRepository _reserveRepository;
        private ICategoryRepository _categoryRepository;
        private IAuthorRepository _authorRepository;
        private ILanguageRepository _languageRepository;
        private IReportRepository _reportRepository;

        protected static IMapper Mapper
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

        protected IBookRepository BookRepository
        {
            get
            {
                if (_bookRepository == null)
                    _bookRepository = new BookRepository();
                return _bookRepository;
            }
        }

        protected IUserRepository UserRepository
        {
            get
            {
                if (_userRepository == null)
                    _userRepository = new UserRepository();
                return _userRepository;
            }
        }

        protected IBookLoanRepository BookLoanRepository
        {
            get
            {
                if (_bookLoanRepository == null)
                    _bookLoanRepository = new BookLoanRepository();
                return _bookLoanRepository;
            }
        }

        protected IReserveRepository ReserveRepository
        {
            get
            {
                if (_reserveRepository == null)
                    _reserveRepository = new ReserveRepository();
                return _reserveRepository;
            }
        }

        protected ICategoryRepository CategoryRepository
        {
            get
            {
                if (_categoryRepository == null)
                    _categoryRepository = new CategoryRepository();
                return _categoryRepository;
            }
        }

        protected IAuthorRepository AuthorRepository
        {
            get
            {
                if (_authorRepository == null)
                    _authorRepository = new AuthorRepository();
                return _authorRepository;
            }
        }

        protected ILanguageRepository LanguageRepository
        {
            get
            {
                if (_languageRepository == null)
                    _languageRepository = new LanguageRepository();
                return _languageRepository;
            }
        }

        protected IReportRepository ReportRepository
        {
            get
            {
                if (_reportRepository == null)
                    _reportRepository = new ReportRepository();
                return _reportRepository;
            }
        }
    }
}
