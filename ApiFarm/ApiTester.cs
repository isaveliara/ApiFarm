using System.Text;
using System.Text.Json;

namespace FarmAPI
{
    public static class ApiTester
    {
        private static readonly HttpClient client = new HttpClient();

        public static async Task RunTests()
        {
            client.BaseAddress = new Uri("http://localhost:5145/api/"); //minha api olha

            //instanciar um novo cara
            var newUser = new{
                Name = "Joaozinho Lan Code",
                Level = 1,
                Money = 1000
            };
            var response = await client.PostAsync(
                "Users", new StringContent(JsonSerializer.Serialize(newUser),
                Encoding.UTF8, "application/json"));
            
            Console.WriteLine($"User Response: {await response.Content.ReadAsStringAsync()}");

            response = await client.GetAsync("Users");
            Console.WriteLine($"Get Users Response: {await response.Content.ReadAsStringAsync()}");

            //plantinhainha
            var newPlant = new{
                Name = "Banana", Season = "Summer",
                Description = "A tropical fruit.",
                SpaceRequired = 2,
                GrowthTime = 7, Value = 5
            };
            response = await client.PostAsync("Plants", new StringContent(JsonSerializer.Serialize(newPlant), Encoding.UTF8, "application/json"));
            Console.WriteLine($"Create Plant Response: {await response.Content.ReadAsStringAsync()}");

            //buscar plantas
            response = await client.GetAsync("Plants");
            Console.WriteLine($"Get Plants Response: {await response.Content.ReadAsStringAsync()}");
        }
    }
}
