using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pastures.Models
{
    [Table("zemfondpol", Schema = "public")]
    public class zemfondpol
    {
        public int gid { get; set; }
        public int objectid { get; set; }
        public int type_k { get; set; }
        public decimal ur_avgyear { get; set; }
        public int dominant_t { get; set; }
        public decimal korm_avgye { get; set; }
        public decimal area { get; set; }
        public int s_recomend { get; set; }
        public int subtype_k { get; set; }
        public string kato_te_1 { get; set; }
        public decimal shape_leng { get; set; }
        public decimal shape_area { get; set; }
    }
}