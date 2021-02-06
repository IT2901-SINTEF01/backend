namespace Backend.API.Queries.Resolvers
{
    // Perhaps move to Singleton with Dependency Injection?
    public static class SampleResolver
    {
        public static string Value()
        {
            return "Hello, GraphQL!";
        }
    }
}