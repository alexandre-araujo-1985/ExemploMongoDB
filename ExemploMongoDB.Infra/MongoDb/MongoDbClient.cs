using MongoDB.Driver;

namespace ExemploMongoDB.Infra.MongoDb
{
	public class MongoDbClient<T> where T : class
	{
		private static IMongoClient Conectar()
		{
			string connectionString = "mongodb://localhost:27017"; // Example connection string

			var client = new MongoClient(connectionString);
			return client;
		}

		public static IMongoCollection<T> GetCollection(string nomeCollection)
		{
			var collection = Conectar().GetDatabase("EstudoMongoDb").GetCollection<T>(nomeCollection);

			return collection;
		}
	}
}
