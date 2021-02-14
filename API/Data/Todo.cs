using System.Text.Json.Serialization;

namespace Backend.API.Data
{
    public class Todo
    {
        [JsonPropertyName("userId")] public int UserId { get; set; }

        [JsonPropertyName("id")] public int Id { get; set; }

        [JsonPropertyName("title")] public string Title { get; init; }

        [JsonPropertyName("completed")] public bool Completed { get; set; }
    }
}