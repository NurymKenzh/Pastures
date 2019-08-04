using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pastures.Models
{
    [Table("Catoes", Schema = "public")]
    public class CATO
    {
        public int Id { get; set; }
        public string AB { get; set; }
        public string CD { get; set; }
        public string EF { get; set; }
        public string HIJ { get; set; }

        public string K { get; set; }

        [Display(Name = "Название")]
        public string Name { get; set; }

        [Display(Name = "Название (каз.)")]
        public string NameKZ { get; set; }

        public string TE
        {
            get
            {
                return AB + CD + EF + HIJ;
            }

        }

    }
}