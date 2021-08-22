using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dz1Plakas.Models
{
    public class Brend
    {

        [Display(Name="id")]
        public int id { get; set; }
        public string name { get; set; }

        //public ICollection <Product> products { get; set; }

    }
}
