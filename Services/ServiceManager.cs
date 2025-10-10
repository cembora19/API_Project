using AutoMapper;
using Repositories.Contracts; // Bu using önemli
using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBookService> _bookService;

        public ServiceManager(IRepositoryManager repositoryManager, ILoggerService logger, IMapper mapper) // 🔹 burada değişiklik
        {
            _bookService = new Lazy<IBookService>(() => new BookManager(repositoryManager, logger, mapper));
        }

        public IBookService BookService => _bookService.Value;
    }
}
