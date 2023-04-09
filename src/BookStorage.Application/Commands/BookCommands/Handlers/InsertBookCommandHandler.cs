using BookStorage.Application.Commands.Interfaces;
using BookStorage.Domain.Entities;
using BookStorage.Domain.Repositories;

namespace BookStorage.Application.Commands.BookCommands.Handlers
{
    public class InsertBookCommandHandler : ICommandHandler<InsertBookCommand, int>
    {
        private readonly IBookRepository _bookRepository;
        public InsertBookCommandHandler(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<int> HandleAsync(InsertBookCommand command, CancellationToken cancellationToken)
        {
            var entity = new Book
            {
                Name = command.Name,
                Description = command.Description,
                AuthorId = command.AuthorId,
                PublishDate = command.PublishDate,
                Genre = command.Genre
            };
            return await _bookRepository.AddBookAsync(entity);
        }
    }
}
