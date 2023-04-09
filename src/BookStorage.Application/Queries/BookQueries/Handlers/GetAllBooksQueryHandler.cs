using BookStorage.Application.Dtos;
using BookStorage.Application.Queries.Interfaces;
using BookStorage.Domain.Entities;
using BookStorage.Domain.Repositories;

namespace BookStorage.Application.Queries.BookQueries.Handlers
{
    public class GetAllBooksQueryHandler : IQueryHandler<GetAllBooksQuery, IReadOnlyCollection<BookReadDto>>
    {
        private readonly IBookRepository _bookRepository;
        public GetAllBooksQueryHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<IReadOnlyCollection<BookReadDto>> HandleAsync(GetAllBooksQuery query, CancellationToken cancellationToken)
        {
            var list = await _bookRepository.GetAllAsync();
            return list.Select(MapBook).ToList();
        }

        private BookReadDto MapBook(Book book)
        {
            return new BookReadDto
            {
                Id = book.Id,
                Name = book.Name,
                Description = book.Description,
                AuthorId = book.AuthorId,
                Genre = book.Genre,
                PublishDate = book.PublishDate
            };
        }
    }
}
