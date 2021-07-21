using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dz1Plakas.Models
{
    public class CarColor
    {
        public int id { get; set; }
        [Display(Name = "Название цвета")]
        [DisplayFormat(NullDisplayText ="Нет данных")]
        public string name { get; set; }
        [Display(Name = "Код цвета")]
        [DisplayFormat(NullDisplayText = "Нет данных")]
        public string rgb { get; set; }
        [Display(Name = "Ссылка на картинку")]
        [DisplayFormat(NullDisplayText = "Нет данных")]

        public string url { get; set; }
        


    }
}
