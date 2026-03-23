using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hondenras.Domain.DTOs
{
    public class DogBreedsResponse
    {
        public Dictionary<string, List<string>> Message { get; set; }
        public string Status { get; set; }
    }
}
