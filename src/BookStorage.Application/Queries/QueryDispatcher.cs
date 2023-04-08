using BookStorage.Application.Commands.Interfaces;
using BookStorage.Application.Queries.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStorage.Application.Queries
{
    public class QueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;
        public QueryDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task<TQueryResult> Dispatch<TQuery, TQueryResult>(TQuery query, CancellationToken cancellationToken)
        {
            try
            {
                var queryHandler = _serviceProvider.GetRequiredService<IQueryHandler<TQuery, TQueryResult>>();
                return await queryHandler.HandleAsync(query, cancellationToken);
            }
            catch (InvalidOperationException ex)
            {
                throw new ArgumentNullException($"Handler not found for {query.GetType().Name} command. {ex.Message}");
            }
        }
    }
}
