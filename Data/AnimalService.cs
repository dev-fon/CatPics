using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace CatPics.Data
{
    public class AnimalService
    {
        private readonly HttpClient httpClient;
        private const string url = "https://api.thecatapi.com/v1/images/search?breed_ids=beng&include_breeds=true"; // Store in config

        public AnimalService()
        {
            httpClient = new HttpClient();

            // TODO: move this into a config file at some point
            httpClient.DefaultRequestHeaders.Add("x-api-key", "b8fda99d-ca7c-4c47-84a8-e8229f8ba572");
            //httpClient.DefaultRequestHeaders.Add("x-api-key", "_YOUR_API_KEY_HERE");
        }

        public async Task<Animal[]> GetAnimals()
        {
            var result = await this.httpClient.GetStringAsync(url);
            var converted = JsonConvert.DeserializeObject<Animal[]>(result);
            return converted;
        }
    }
}
