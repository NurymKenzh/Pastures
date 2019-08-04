using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pastures.Models
{
    [Table("wellspol", Schema = "public")]
    public class wellspol
    {
        public int gid { get; set; }
        public int objectid { get; set; }
        public int class_id { get; set; }
        public decimal shape_leng { get; set; }
        public decimal shape_area { get; set; }
    }
}