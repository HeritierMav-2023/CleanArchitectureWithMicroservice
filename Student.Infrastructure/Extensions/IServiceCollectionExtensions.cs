using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Student.Application.Interfaces;
using Student.Infrastructure.Repository;


namespace Student.Infrastructure.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddPersistenceLayer(this IServiceCollection services)
        {
            services.AddRepositories();
        }

        private static void AddRepositories(this IServiceCollection services)
        {
            services
                .AddTransient<IMediator, Mediator>()
                .AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork))
                .AddTransient<IStudentRepository, StudentRepository>();
        }
    }
}
