using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Backend.Mocks.Metadata;
using Backend.Models.Base.Metadata;
using Backend.Models.Base.Metadata.POCO;
using MongoDB.Driver;

namespace Backend.API.Services
{
    public interface IMetadataService
    {
        public Task<StoredMetadata> GetMetadata(string name);
        public Task<Collection<StoredMetadata>> GetAllMetadata();
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

        public async Task<StoredMetadata> GetMetadata(string name)
        {
            return await Task.FromResult(_storedMetadata.Find(data => data.Name == name).FirstOrDefault());
        }

        public async Task<Collection<StoredMetadata>> GetAllMetadata()
        {
            var result = await Task.FromResult(_storedMetadata.Find(metadata => true).ToList()).ConfigureAwait(false);
            return new Collection<StoredMetadata>(result);
        }
    }

    public class MetadataServiceMocked : IMetadataService
    {
        public async Task<StoredMetadata> GetMetadata(string name)
        {
            return await Task.FromResult(MockMetadata.GenerateStoredMetadata());
        }

        public async Task<Collection<StoredMetadata>> GetAllMetadata()
        {
            return await Task.FromResult(MockMetadata.GenerateMultipleStoredMetadata()).ConfigureAwait(false);
        }
    }
}