using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pastures.Models
{
    [Table("CATOSpecies", Schema = "public")]
    public class CATOSpecies
    {
        public int Id { get; set; }

        [Display(Name = "КАТО")]
        public string CATOTE { get; set; }


        [Display(Name = "Код")]
        public int Code { get; set; }
    }
}