using ExemploMongoDB.Domain.Entities;

namespace ExemploMongoDB.Domain.Contracts.Repositories
{
	public interface IClienteRepository
	{
		Cliente Pesquisar(Cliente cliente);
		void Incluir(Cliente cliente);
		void Alterar(Cliente cliente);
	}
}
