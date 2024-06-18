using ExemploMongoDB.Domain.Entities;

namespace ExemploMongoDB.Requests
{
	public class PesquisarClienteRequest
	{
		public string? Nome { get; set; }
		public DateTime DataCadastro { get; set; }
		public DateTime DataAlteracao { get; set; }
		public bool? Status { get; set; } = null;

		public static Cliente ConvertToCliente(string id, PesquisarClienteRequest clienteRequest)
		{
			return new Cliente
			{
				Id = id,
				Nome = clienteRequest.Nome,
				DataCadastro = clienteRequest.DataCadastro,
				DataAlteracao = clienteRequest.DataAlteracao,
				Status = clienteRequest.Status
			};
		}
	}
}
