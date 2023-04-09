using BookStorage.Domain.Entities;

namespace BookStorage.Domain.Repositories
{
    public interface IBookRepository
    {
        Task<int> AddBookAsync(Book entity);
    }
}