using System;
using System.Threading.Tasks;
using Backend.Models.Base.MetaData;
using Backend.Models.Base.MetaData.POCO;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Backend.API.Services
{
    public interface IMetaDataService
    {
        public Task<StoredMetaData> GetMetaData(string name);
    }

    public class MetaDataService : IMetaDataService
    {
        private readonly IMongoCollection<StoredMetaData> _storedMetaData;

        public MetaDataService(IMetaDataDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _storedMetaData = database.GetCollection<StoredMetaData>(settings.MetaDataCollectionName);
        }

        public async Task<StoredMetaData> GetMetaData(string name)
        {
            Console.WriteLine(_storedMetaData.Find(new BsonDocument()).FirstOrDefault().ToString());
            var response = await Task.FromResult(_storedMetaData.Find(data => data.Name == name).FirstOrDefault());
            return response;
        }
    }
}