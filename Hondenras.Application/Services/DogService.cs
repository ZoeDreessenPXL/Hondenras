using Hondenras.Domain.Models;
using Hondenras.Infrastructure.Repositories;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hondenras.Application.Services
{
    public class DogService
    {
        private DogRepository _dogRepo = new DogRepository();
        public List<DogBreed> Breeds { get; private set; }
        public DogBreed CurrentBreed { get; set; }

        public async Task InitializeAsync()
        {
            Breeds = await _dogRepo.GetAllBreedsAsync();
            Breeds = Breeds.OrderBy(b => b.ToString()).ToList();
        }

        public async Task<string> GetNextDogImageAsync()
        {
            CurrentBreed = GetRandomDogBreed();
            return await _dogRepo.GetRandomImageUrlByBreedAsync(CurrentBreed);
        }

        private DogBreed GetRandomDogBreed()
        {
            Random rnd = new Random();
            return Breeds[rnd.Next(Breeds.Count)];
        }

        public bool Guess(DogBreed selectedBreed)
        {
            return selectedBreed.Equals(CurrentBreed);
        }
    }
}
