using System.Threading.Tasks;
using Backend.API.Data;
using Backend.API.Services;
using GraphQL.Types;

namespace Backend.API.Queries
{
    public class Query : ObjectGraphType
    {
        public Query(IDataRetrievalService dataRetrievalService)
        {
            Field<TodoType>("todo", resolve: _ => dataRetrievalService.GetTodo());
        }
    }
}