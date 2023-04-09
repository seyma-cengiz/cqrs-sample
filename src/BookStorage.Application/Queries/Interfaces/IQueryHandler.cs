namespace BookStorage.Application.Queries.Interfaces
{
    public interface IQueryHandler<in TQuery, TQueryResult>
    {
        Task<TQueryResult> HandleAsync(TQuery query, CancellationToken cancellationToken);
    }
}
