using ExemploMongoDB.Domain.Entities;

namespace ExemploMongoDB.Domain.Contracts.Services
{
	public interface IClienteService
	{
		Cliente Pesquisar(Cliente cliente);
		void Incluir(Cliente cliente);
		void Alterar(Cliente cliente);
	}
}
