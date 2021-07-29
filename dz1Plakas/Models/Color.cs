using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dz1Plakas.Models
{
    public class Color
    {
        public int id { get; set; }
        public string name { get; set; }

        public ICollection<ColorProducts> colorProducts { get; set; }

        //public ICollection<Product> products { get; set; }
    }
}
