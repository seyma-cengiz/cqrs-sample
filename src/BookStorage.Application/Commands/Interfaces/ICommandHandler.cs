using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStorage.Application.Commands.Interfaces
{
    public interface ICommandHandler<in TCommand, TCommandResult>
    {
        Task<TCommandResult> HandleAsync(TCommand command, CancellationToken cancellationToken);
    }
}
