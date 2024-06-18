using ExemploMongoDB.Application.Services;
using ExemploMongoDB.Domain.Contracts.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ExemploMongoDB.Application.DependencyInjections
{
	public static class ServiceDependency
	{
		public static void ClientDIServices(this IServiceCollection services)
		{
			services.AddTransient<IClienteService, ClienteService>();
		}
	}
}
