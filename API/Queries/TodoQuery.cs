using System.Threading.Tasks;
using Backend.API.Data;
using Backend.API.Services;
using GraphQL;
using GraphQL.Types;

namespace Backend.API.Queries
{
    public class TodoQuery : ObjectGraphType
    {
        public TodoQuery(IDataRetrievalService dataRetrievalService)
        {
            Field<TodoType>("todo", arguments: new QueryArguments()
            {
                new QueryArgument<IntGraphType>
                    {Name = "id", Description = "The ID of the todo to retrieve.", DefaultValue = 1}
            }, resolve: context => dataRetrievalService.GetTodo(context.GetArgument<int>("id")));

            Field<ListGraphType<TodoType>>("todos", resolve: _ => dataRetrievalService.GetTodos());
        }
    }
}