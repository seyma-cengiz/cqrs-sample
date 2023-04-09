using BookStorage.Domain.Entities;

namespace BookStorage.Domain.Repositories
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<int> AddBookAsync(Book entity);
    }
}