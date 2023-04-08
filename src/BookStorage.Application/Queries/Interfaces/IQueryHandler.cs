using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStorage.Application.Queries.Interfaces
{
    public interface IQueryHandler<in TQuery, TQueryResult>
    {
        Task<TQueryResult> HandleAsync(TQuery command, CancellationToken cancellationToken);
    }
}
