using BookStorage.Application.Commands.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStorage.Application.Commands
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IServiceProvider _serviceProvider;
        public CommandDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public async Task<TCommandResult> Dispatch<TCommand, TCommandResult>(TCommand command, CancellationToken cancellationToken)
        {
            //https://andrewlock.net/the-difference-between-getservice-and-getrquiredservice-in-asp-net-core/
            //GetService() returns null if a service does not exist, GetRequiredService() throws an exception instead. If you're using a third-party container, use GetRequiredService where possible - in the event of an exception, the third party container may be able to provide diagnostics so you can work out why an expected service wasn't registered.
            try
            {
                var commandHandler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand, TCommandResult>>();
                return await commandHandler.HandleAsync(command, cancellationToken);
            }
            catch (InvalidOperationException ex)
            {
                throw new ArgumentNullException($"Handler not found for {command.GetType().Name} command. {ex.Message}");
            }
        }
    }
}
