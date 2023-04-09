using BookStorage.Application.Commands;
using BookStorage.Application.Commands.Interfaces;
using BookStorage.Application.Queries;
using BookStorage.Application.Queries.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace BookStorage.Application.DependencyResolver
{
    public static class ServiceCollectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            //https://stackoverflow.com/questions/48185894/when-to-use-tryaddsingleton-or-addsingleton
            //AddSingleton always appends the registration to the collection, while TryAddSingleton only does this when there exists no registration for the given service type.
            //When multiple registrations exist for the same service type, but a single instance is requested, .NET Core will always return the last one registered.This means that the behavior of AddSingleton is to effectively replace instances for non - collection resolution

            services.TryAddSingleton<ICommandDispatcher, CommandDispatcher>();
            services.TryAddSingleton<IQueryDispatcher, QueryDispatcher>();

            services.Scan(selector =>
            {
                selector.FromCallingAssembly()
                        .AddClasses(filter =>
                        {
                            filter.AssignableTo(typeof(ICommandHandler<,>));
                        })
                        .AsImplementedInterfaces()
                        .WithSingletonLifetime();
            });
        }
    }
}
