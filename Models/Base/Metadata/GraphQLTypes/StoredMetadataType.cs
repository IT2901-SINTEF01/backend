using Backend.Models.Base.Metadata.POCO;
using GraphQL.Types;

namespace Backend.Models.Base.Metadata.GraphQLTypes
{
    public sealed class StoredMetadataType : ObjectGraphType<StoredMetadata>
    {
        public StoredMetadataType()
        {
            Field(data => data.Id);
            Field(data => data.Name);
            Field(data => data.Description);
            Field(data => data.Tags, false, typeof(ListGraphType<StringGraphType>));
            Field(data => data.Source);
            Field(data => data.Updated);
            Field(data => data.Published);
            Field(data => data.Visualisations, false, typeof(ListGraphType<VisualisationType>));
        }
    }
}