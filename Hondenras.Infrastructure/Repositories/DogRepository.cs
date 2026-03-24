using Hondenras.Domain.DTOs;
using Hondenras.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Hondenras.Infrastructure.Repositories
{
    public class DogRepository
    {
        public async Task<List<DogBreed>> GetAllBreedsAsync()
        {
            List<DogBreed> breeds = new List<DogBreed>();

            HttpClient httpClient = new HttpClient();
            string content = await httpClient.GetStringAsync("https://dog.ceo/api/breeds/list/all");

            var breedsResponse = JsonSerializer.Deserialize<DogBreedsResponse>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            foreach(var breed in breedsResponse.Message)
            {
                if (breed.Value.Count > 0)
                {
                    foreach (var subBreed in breed.Value)
                    {
                        breeds.Add(new DogBreed() { Name = breed.Key, SubBreed = subBreed });
                    }
                }
                else
                {
                    breeds.Add(new DogBreed() { Name = breed.Key });
                }
            }

            return breeds;
        }

        public async Task<string> GetRandomImageUrlByBreedAsync(DogBreed breed)
        {
            string url = @$"https://dog.ceo/api/breed/{breed.Name}/images/random";
            if (!string.IsNullOrWhiteSpace(breed.SubBreed))
            {
                url = @$"https://dog.ceo/api/breed/{breed.Name}/{breed.SubBreed}/images/random";
            }

            HttpClient client = new HttpClient();
            string imageUrl = await client.GetStringAsync(url);

            return JsonSerializer.Deserialize<DogImageResponse>(imageUrl, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }).Message;
        }
    }
}
