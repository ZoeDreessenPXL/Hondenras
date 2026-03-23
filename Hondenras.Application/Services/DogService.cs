using Hondenras.Domain.Models;
using Hondenras.Infrastructure.Repositories;
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

        public async Task GetData()
        {
            Breeds = await _dogRepo.GetData();
        }
    }
}
