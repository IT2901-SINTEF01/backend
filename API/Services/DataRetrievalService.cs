using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Backend.API.Data;

namespace Backend.API.Services
{
    public interface IDataRetrievalService
    {
        HttpClient HttpClient { get; init; }

        Task<Todo> GetTodo();
    }

    public class DataRetrievalService : IDataRetrievalService
    {
        public HttpClient HttpClient { get; init; }

        public DataRetrievalService()
        {
            this.HttpClient = new HttpClient();
            this.HttpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            this.HttpClient.DefaultRequestHeaders.UserAgent.ParseAdd(
                "Mozilla/5.0 (Macintosh; Intel Mac OS X x.y; rv:42.0) Gecko/20100101 Firefox/42.0");
        }

        public async Task<Todo> GetTodo()
        {
            HttpResponseMessage response = await this.HttpClient.GetAsync("https://jsonplaceholder.typicode.com/todos/1");
            return await response.Content.ReadFromJsonAsync<Todo>();
        }
    }
}