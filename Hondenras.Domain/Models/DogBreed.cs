using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hondenras.Domain.Models
{
    public class DogBreed
    {
        public string Name { get; set; }
        public string SubBreed { get; set; }

        public override string ToString()
        {
            return $"{Name} {SubBreed}";
        }
    }
}
