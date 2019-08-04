using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pastures.Models
{
    [Table("SmallCattles", Schema = "public")]
    public class SmallCattle
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

        [Display(Name = "Настриг шерсти")]
        public string Shearings { get; set; }

        [Display(Name = "Выход мытой шерсти")]
        public string WashedWoolYield { get; set; }

        [Display(Name = "Плодовитость")]
        public string Fertility { get; set; }

        [Display(Name = "Длина шерсти")]
        public string WoolLength { get; set; }

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