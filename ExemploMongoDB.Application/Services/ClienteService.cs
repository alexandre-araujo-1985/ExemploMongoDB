using ExemploMongoDB.Domain.Entities;
using ExemploMongoDB.Domain.Contracts.Services;
using ExemploMongoDB.Domain.Contracts.Repositories;

namespace ExemploMongoDB.Application.Services
{
	public class ClienteService : IClienteService
	{
		private readonly IClienteRepository _clienteRepository;

		public ClienteService(IClienteRepository clienteRepository)
		{
			_clienteRepository = clienteRepository;
		}

		public void Alterar(Cliente cliente) => _clienteRepository.Alterar(cliente);

		public void Incluir(Cliente cliente) => _clienteRepository.Incluir(cliente);

		public Cliente Pesquisar(Cliente cliente) => _clienteRepository.Pesquisar(cliente);
	}
}
