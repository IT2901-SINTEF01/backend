using GraphQL.Types;

namespace Backend.API.Data
{
    public sealed class TodoType : ObjectGraphType<Todo>
    {
        public TodoType()
        {
            Field(todo => todo.UserId);
            Field(todo => todo.Id);
            Field(todo => todo.Title);
            Field(todo => todo.Completed);
        }
    }
}