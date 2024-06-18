using MongoDB.Bson;
using ExemploMongoDB.Domain.Entities;
using MongoDB.Bson.Serialization.Attributes;

namespace ExemploMongoDB.Infra.Collections
{
	public class ClienteCollection
	{
		[BsonId]
		public ObjectId Id { get; set; }
		public string? Nome { get; set; }
		public DateTime DataCadastro { get; set; }
		public DateTime DataAlteracao { get; set; }
		public bool Status { get; set; }

		public static ClienteCollection ConvertToEntity(Cliente cliente)
		{
			return new ClienteCollection
			{
				Nome = cliente.Nome,
				DataCadastro = cliente.DataCadastro,
				DataAlteracao = cliente.DataAlteracao,
				Status = cliente.Status!.Value
			};
		}

		public static Cliente ConvertToCollection(ClienteCollection cliente)
		{
			return new Cliente
			{
				Nome = cliente.Nome,
				DataCadastro = cliente.DataCadastro,
				DataAlteracao = cliente.DataAlteracao,
				Status = cliente.Status
			};
		}
	}
}
