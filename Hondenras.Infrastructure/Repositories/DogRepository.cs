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
        public async Task<List<DogBreed>> GetData()
        {
            List<DogBreed> breeds = new List<DogBreed>();

            HttpClient httpClient = new HttpClient();
            string content = await httpClient.GetStringAsync("https://dog.ceo/api/breeds/list/all");

            var test = JsonSerializer.Deserialize<DogBreedsResponse>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            foreach(var breed in test.Message)
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
    }
}
