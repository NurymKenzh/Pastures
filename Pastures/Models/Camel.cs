using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Helpers;

namespace Pastures.Models
{
    [Table("Camels", Schema = "public")]
    public class Camel
    {
        public int Id { get; set; }

        [Display(Name = "Код")]
        public int Code { get; set; }

        [Display(Name = "Порода")]
        public string Breed { get; set; }

        [Display(Name = "Живая масса")]
        public string Weight { get; set; }

        [Display(Name = "Убойный выход")]
        public decimal SlaughterYield { get; set; }

        [Display(Name = "Удой маток")]
        public string EwesYield { get; set; }

        [Display(Name = "Всего голов")]
        public int TotalGoals { get; set; }

        [Display(Name = "Жирность молока")]
        public string MilkFatContent { get; set; }

        [Display(Name = "Ареал разведения")]
        public string Range { get; set; }

        [Display(Name = "Фото")]
        public byte[] Photo { get; set; }

        [Display(Name = "Примечание")]
        public string Description { get; set; }
    }
}