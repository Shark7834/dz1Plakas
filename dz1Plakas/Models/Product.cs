using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dz1Plakas.Models
{
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }

        public Brend brend { get; set; }

       // public int brendId { get; set; }

    }
}
