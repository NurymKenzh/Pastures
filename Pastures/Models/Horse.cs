using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pastures.Models
{
    [Table("Horses", Schema = "public")]
    public class Horse
    {
        public int Id { get; set; }

        [Display(Name = "Код")]
        public int Code { get; set; }

        [Display(Name = "Порода")]
        public string Breed { get; set; }

        [Display(Name = "Направление")]
        public string Direction { get; set; }

        [Display(Name = "Живая масса жеребцов и кобыл")]
        public string Weight { get; set; }

        [Display(Name = "Высота в холке")]
        public string Height { get; set; }

        [Display(Name = "Молочная продуктивность")]
        public string MilkYield { get; set; }

        [Display(Name = "Длина туловища")]
        public string BodyLength { get; set; }

        [Display(Name = "Обхват груди")]
        public string Bust { get; set; }

        [Display(Name = "Обхват пясти")]
        public string Metacarpus { get; set; }

        [Display(Name = "Всего голов")]
        public int TotalGoals { get; set; }

        [Display(Name = "Выведена")]
        public string Bred { get; set; }

        [Display(Name = "Ареал разведения")]
        public string Range { get; set; }

        [Display(Name = "Фото")]
        public byte[] Photo { get; set; }

        [Display(Name = "Примечание")]
        public string Description { get; set; }
    }
}