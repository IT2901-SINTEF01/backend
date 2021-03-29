using Backend.API.Services;
using Backend.Models.Base.Metadata.GraphQLTypes;
using GraphQL.Types;

namespace Backend.utils.GraphQLTypes
{
    /// <summary>
    ///     Creates an object graph type (from GraphQL) with the associated metadata field retrieved from a MongoDB database.
    /// </summary>
    /// <typeparam name="T">The type which contains the data for which the metadata is associated.</typeparam>
    public abstract class ObjectGraphTypeWithMetadata<T> : ObjectGraphType<T>
    {
        protected ObjectGraphTypeWithMetadata(IMetadataService metadataService, string metadataDocumentName)
        {
            Field<StoredMetadataType>()
                .ResolveAsync(async _ => await metadataService.GetMetadata(metadataDocumentName))
                .Name("metadata")
                .Description($"Metadata for a data source with the name {metadataDocumentName}.");
        }
    }
}