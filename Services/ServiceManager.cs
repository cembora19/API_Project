using Repositories.Contracts; // Bu using önemli
using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IBookService> _bookService;

        public ServiceManager(IRepositoryManager repositoryManager) // 🔹 burada değişiklik
        {
            _bookService = new Lazy<IBookService>(() => new BookManager(repositoryManager));
        }

        public IBookService BookService => _bookService.Value;
    }
}
