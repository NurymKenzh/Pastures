using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pastures.Models
{
    [Table("Cattles", Schema = "public")]
    public class Cattle
    {
        public int Id { get; set; }

        [Display(Name = "Код")]
        public int Code { get; set; }

        [Display(Name = "Порода")]
        public string Breed { get; set; }

        [Display(Name = "Направление")]
        public string Direction { get; set; }

        [Display(Name = "Живая масса")]
        public string Weight { get; set; }

        [Display(Name = "Убойный выход")]
        public string SlaughterYield { get; set; }

        [Display(Name = "Удой маток")]
        public string EwesYield { get; set; }

        [Display(Name = "Всего голов")]
        public int TotalGoals { get; set; }

        [Display(Name = "Жирность молока")]
        public string MilkFatContent { get; set; }

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