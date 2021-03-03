using System.Threading.Tasks;
using Backend.Mocks.Metadata;
using Backend.Models.Base.Metadata;
using Backend.Models.Base.Metadata.POCO;
using MongoDB.Driver;

namespace Backend.API.Services
{
    public interface IMetadataService
    {
        public Task<object> GetMetadata(string name);
    }

    public class MetadataService : IMetadataService
    {
        private readonly IMongoCollection<StoredMetadata> _storedMetadata;

        public MetadataService(IMetadataDatabaseSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _storedMetadata = database.GetCollection<StoredMetadata>(settings.MetadataCollectionName);
        }

        public async Task<object> GetMetadata(string name)
        {
            return await Task.FromResult(_storedMetadata.Find(data => data.Name == name).FirstOrDefault());
        }
    }

    public class MetadataServiceMocked : IMetadataService
    {
        public async Task<object> GetMetadata(string name)
        {
            return await Task.FromResult(MockMetadata.GenerateStoredMetadata());
        }
    }
}