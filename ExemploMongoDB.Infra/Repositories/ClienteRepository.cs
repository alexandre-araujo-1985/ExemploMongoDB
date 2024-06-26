﻿using MongoDB.Driver;
using ExemploMongoDB.Domain.Entities;
using ExemploMongoDB.Infra.Collections;
using ExemploMongoDB.Domain.Contracts.Repositories;
using ExemploMongoDB.Infra.MongoDb;
using ExemploMongoDB.Domain.Constants;
using MongoDB.Bson;

namespace ExemploMongoDB.Infra.Repositories
{
	public class ClienteRepository : IClienteRepository
	{
		private IMongoCollection<ClienteCollection> _collection;

		public ClienteRepository()
		{
			_collection = MongoDbClient<ClienteCollection>.GetCollection(CollectionConstant.Cliente);
		}

		public void Incluir(Cliente cliente)
		{
			cliente.Status = true;
			_collection.InsertOne(ClienteCollection.ConvertToEntity(cliente));
		}

		public void Alterar(Cliente cliente)
		{
			_ = ObjectId.TryParse(cliente.Id, out var id);

			if (id == ObjectId.Empty)
			{
				return;
			}

			var update = Builders<ClienteCollection>.Update;
			var updates = new List<UpdateDefinition<ClienteCollection>>();
			var filtro = Builders<ClienteCollection>.Filter.Eq(c => c.Id, id);

			if (cliente.Status.HasValue)
			{
				updates.Add(update.Set(c => c.Status, cliente.Status));
			}

			updates.Add(update.Set(c => c.DataAlteracao, DateTime.Now));

			var collection = _collection.UpdateOne(filtro, update.Combine(updates));
		}

		public Cliente Pesquisar(Cliente cliente)
		{
			_ = ObjectId.TryParse(cliente.Id, out var id);

			var filtro = Builders<ClienteCollection>.Filter.Eq(c => c.Id, id);

			if (cliente.Nome != default)
			{
				filtro &= Builders<ClienteCollection>.Filter.Eq(c => c.Nome, cliente.Nome);
			}

			if (cliente.Status.HasValue)
			{
				filtro &= Builders<ClienteCollection>.Filter.Eq(c => c.Status, cliente.Status);
			}

			var collection = _collection.Find(filtro);

			return ClienteCollection.ConvertToCollection(collection?.FirstOrDefault()!)!;
		}

		public IEnumerable<Cliente> ListarTodos()
		{
			var collection = _collection.Find(x => true).ToList();

			return ClienteCollection.ConvertToCollection(collection)!;
		}

		public void Excluir(string id)
		{
			var cliente = new Cliente { Id = id, Status = false };
			Alterar(cliente);
		}
	}
}
