using BookStorage.Domain.Entities;
using BookStorage.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BookStorage.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookStorageDbContext _dbContext;
        public BookRepository(BookStorageDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _dbContext.Books.ToListAsync();
        }

        public async Task<int> AddBookAsync(Book entity)
        {
            await _dbContext.Books.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            return entity.Id;
        }
    }
}