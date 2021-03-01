using Backend.Models.Base.MetaData.POCO;
using GraphQL.Types;

namespace Backend.Models.Base.MetaData.GraphQLTypes
{
    public sealed class StoredMetaDataType : ObjectGraphType<StoredMetaData>
    {
        public StoredMetaDataType()
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