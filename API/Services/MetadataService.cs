using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Backend.Mocks.Metadata;
using Backend.Models.Base.Metadata;
using Backend.Models.Base.Metadata.POCO;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Backend.API.Services
{
    public interface IMetadataService
    {
        public Task<StoredMetadata> GetMetadata(DatasourceId datasourceId);
        public Task<Collection<StoredMetadata>> GetAllMetadata();
    }

    public class MetadataService : IMetadataService
    {
        public readonly IMongoCollection<StoredMetadata> StoredMetadata;

        public MetadataService(IMetadataDatabaseSettings settings, IConfiguration configuration)
        {
            // The : is actually a __ in the environment variables, but it's converted. Ref.
            // https://docs.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-5.0&tabs=windows
            var client = new MongoClient(configuration.GetValue<string>("DATABASE:MONGODB_ATLAS:URL"));
            var database = client.GetDatabase(settings.DatabaseName);

            StoredMetadata = database.GetCollection<StoredMetadata>(settings.MetadataCollectionName);
        }

        public async Task<StoredMetadata> GetMetadata(DatasourceId datasourceId)
        {
            var cursor = await StoredMetadata.FindAsync(data => data.DatasourceId == datasourceId.Value);
            return cursor.Current.First();
        }

        public async Task<Collection<StoredMetadata>> GetAllMetadata()
        {
            var result = await Task.FromResult(StoredMetadata.Find(metadata => true).ToList()).ConfigureAwait(false);
            return new Collection<StoredMetadata>(result);
        }
    }

    public class MetadataServiceMocked : IMetadataService
    {
        public async Task<StoredMetadata> GetMetadata(DatasourceId datasourceId)
        {
            return await Task.FromResult(MockMetadata.GenerateStoredMetadata());
        }

        public async Task<Collection<StoredMetadata>> GetAllMetadata()
        {
            return await Task.FromResult(MockMetadata.GenerateMultipleStoredMetadata()).ConfigureAwait(false);
        }
    }
}