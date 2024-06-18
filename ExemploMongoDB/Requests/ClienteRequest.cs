using ExemploMongoDB.Domain.Entities;

namespace ExemploMongoDB.Requests
{
	public class ClienteRequest
	{
		public string? Id { get; set; }
		public string? Nome { get; set; }
		public DateTime DataCadastro { get; set; }
		public DateTime DataAlteracao { get; set; }
		public bool? Status { get; set; }

		public static Cliente ConvertToCliente(ClienteRequest clienteRequest)
		{
			return new Cliente
			{
				Id = clienteRequest.Id,
				Nome = clienteRequest.Nome,
				DataCadastro = clienteRequest.DataCadastro,
				DataAlteracao = clienteRequest.DataAlteracao,
				Status = clienteRequest.Status
			};
		}
	}
}
