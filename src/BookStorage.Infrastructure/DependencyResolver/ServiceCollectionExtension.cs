using BookStorage.Domain.Entities;
using BookStorage.Domain.Repositories;
using BookStorage.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace BookStorage.Infrastructure.DependencyResolver
{
    public static class ServiceCollectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddDbContext<BookStorageDbContext>(opts => opts.UseInMemoryDatabase("bookmemory-db"), ServiceLifetime.Singleton);

            //seed database
            var dbContext = services.BuildServiceProvider().GetRequiredService<BookStorageDbContext>();
            var book = new Book
            {
                Id = 1,
                Name = "Test",
                Description = "Test",
                AuthorId = 1,
                Genre = "Test",
                PublishDate = DateTime.Now
            };
            dbContext.Books.Add(book);
            dbContext.SaveChanges();

            services.AddSingleton<IBookRepository, BookRepository>();
        }
    }
}