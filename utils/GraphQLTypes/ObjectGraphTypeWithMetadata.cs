using Backend.API.Services;
using Backend.Models.Base.Metadata.GraphQLTypes;
using Backend.Models.Base.Metadata.POCO;
using GraphQL.Types;

namespace Backend.utils.GraphQLTypes
{
    /// <summary>
    ///     Creates an object graph type (from GraphQL) with the associated metadata field retrieved from a MongoDB database.
    /// </summary>
    /// <typeparam name="T">The type which contains the data for which the metadata is associated.</typeparam>
    public abstract class ObjectGraphTypeWithMetadata<T> : ObjectGraphType<T>
    {
        protected ObjectGraphTypeWithMetadata(IMetadataService metadataService, DatasourceId datasourceId)
        {
            Field<StoredMetadataType>()
                .ResolveAsync(async _ => await metadataService.GetMetadata(datasourceId))
                .Name("metadata")
                .Description($"Metadata for a data source with id {datasourceId.Value}.");
        }
    }
}