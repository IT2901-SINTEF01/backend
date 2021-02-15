using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Backend.API.Data;
using Backend.API.Data.GeographicalModels;
using Backend.API.Services;
using GraphQL;
using GraphQL.Types;

namespace Backend.API.Queries
{
    public class Query : ObjectGraphType
    {
        public Query(IDataRetrievalService dataRetrievalService)
        {
            Field<TodoType>("todo", arguments: new QueryArguments()
            {
                new QueryArgument<IntGraphType>
                    {Name = "id", Description = "The ID of the todo to retrieve.", DefaultValue = 1}
            }, resolve: context => dataRetrievalService.GetTodo(context.GetArgument<int>("id")));

            Field<ListGraphType<TodoType>>("todos", resolve: _ => dataRetrievalService.GetTodos());
            Field<ListGraphType<MetApiCompactType>>("geomet", resolve: _ =>
            {
                var jsonAsString = File.ReadAllText(Tools.Tools.AssetsPath + "MetApiTestData.json");
                return JsonSerializer.Deserialize<MetApiCompact.Root[]>(jsonAsString);
            });
        }
    }
}