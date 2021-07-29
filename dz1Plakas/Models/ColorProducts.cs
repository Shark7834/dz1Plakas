using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dz1Plakas.Models
{
    public class ColorProducts
    {
        public int colorid { get; set; }
        public Color color { get; set; }

        public int productid { get; set; }
        public Product product { get; set; }

    }
}
