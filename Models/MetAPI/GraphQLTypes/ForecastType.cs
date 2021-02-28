using Backend.Models.Base.MetaData.GraphQLTypes;
using Backend.Models.MetAPI.POCO;
using GraphQL.Types;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Backend.Models.MetAPI.GraphQLTypes
{
    public sealed class ForecastType : ObjectGraphType<Forecast>
    {
        public ForecastType()
        {
            Field(forecast => forecast.ForecastGeometry, false, typeof(GeometryType))
                .Description("The Geo-Data used in the query");
            Field(forecast => forecast.ForecastProperties, false, typeof(PropertiesType))
                .Description("Data and meta-data returned");
            Field(forecast => forecast.Type);

            // What the actual metadata should look like, is hopefully compatible with most databases 
            Field(forecast => forecast.StoredMetaData, false, typeof(StoredMetaDataType));

            // Very bad and temporarily workaround connecting to a Atlas Cluster containing some metadata documents 
            // connect using MongoClient
            var dbClient =
                new MongoClient(
                    "mongodb+srv://new_user_31:<password>@cluster0.3cgl6.mongodb.net/metadata?retryWrites=true&w=majority");
            var database = dbClient.GetDatabase("metadata");
            var collection = database.GetCollection<BsonDocument>("meta");
            var firstDocument = collection.Find(new BsonDocument()).FirstOrDefault();

            // declare variables
            var _id = firstDocument["_id"].ToString();
            var name = firstDocument["name"].ToString();
            var description = firstDocument["description"].ToString();
            var tags = firstDocument["tags"].ToString();
            var source = firstDocument["source"].ToString();
            var updated = firstDocument["updated"].ToString();
            var published = firstDocument["published"].ToString();
            var visualisations =
                firstDocument["visualisations"].ToString(); // Not properly nested when done like this..

            // Set them as fields
            Field(forecast => _id);
            Field(forecast => name);
            Field(forecast => tags);
            Field(forecast => source);
            Field(forecast => updated);
            Field(forecast => published);
            Field(forecast => description);
            Field(forecast => visualisations);

            // The whole document as a string
            var stringDocument = firstDocument.ToString();
            Field(forecast => stringDocument);
        }

        /*
         * The expression continues to resolve the type until the object is completely nested
         */
    }
}