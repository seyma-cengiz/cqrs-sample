using BookStorage.Application.Commands.BookCommands;
using BookStorage.Application.Commands.Interfaces;
using BookStorage.Application.Dtos;
using BookStorage.Application.Queries.BookQueries;
using BookStorage.Application.Queries.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BookStorage.Api.Controllers
{
    [ApiController]
    [Route("api/controller")]
    public class BookController : Controller
    {
        private readonly IQueryDispatcher _queryDispatcher;
        private readonly ICommandDispatcher _commandDispatcher;

        public BookController(IQueryDispatcher queryDispatcher, ICommandDispatcher commandDispatcher)
        {
            _queryDispatcher = queryDispatcher;
            _commandDispatcher = commandDispatcher;
        }

        [HttpGet]
        public async Task<ActionResult> GetAll(CancellationToken cancellationToken)
        {
            var list = await _queryDispatcher.Dispatch<GetAllBooksQuery, IReadOnlyCollection<BookReadDto>>(new GetAllBooksQuery(), cancellationToken);
            return Ok(list);
        }

        [HttpPost]
        public async Task<ActionResult> Create(BookWriteDto dto, CancellationToken cancellationToken)
        {
            var command = new InsertBookCommand
            {
                Name = dto.Name,
                Description = dto.Description,
                AuthorId = dto.AuthorId,
                PublishDate = dto.PublishDate,
                Genre = dto.Genre
            };
            var entityId = await _commandDispatcher.Dispatch<InsertBookCommand, int>(command, cancellationToken);
            return Ok(entityId);
        }
    }
}
