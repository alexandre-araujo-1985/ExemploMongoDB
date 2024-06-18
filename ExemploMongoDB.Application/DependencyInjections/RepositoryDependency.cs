using ExemploMongoDB.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;
using ExemploMongoDB.Domain.Contracts.Repositories;

namespace ExemploMongoDB.Application.DependencyInjections
{
	public static class RepositoryDependency
	{
		public static void ClientDIRepositories(this IServiceCollection services)
		{
			services.AddTransient<IClienteRepository, ClienteRepository>();
		}
	}
}
