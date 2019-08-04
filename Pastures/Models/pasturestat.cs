using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pastures.Models
{
    [Table("pasturestat", Schema = "public")]
    public class pasturestat
    {
        public int gid { get; set; }
        public int fid_pastur { get; set; }
        public decimal __gid { get; set; }
        public decimal objectid { get; set; }
        public decimal class_id { get; set; }
        public decimal relief_id { get; set; }
        public decimal zone_id { get; set; }
        public decimal subtype_id { get; set; }
        public decimal group_id { get; set; }
        public decimal ur_v { get; set; }
        public decimal ur_l { get; set; }
        public decimal ur_o { get; set; }
        public decimal ur_z { get; set; }
        public decimal korm_v { get; set; }
        public decimal korm_l { get; set; }
        public decimal korm_o { get; set; }
        public decimal korm_z { get; set; }
        public decimal recommend_ { get; set; }
        public decimal recom_catt { get; set; }
        public decimal haying_id { get; set; }
        public decimal otdely_id { get; set; }
        public string kato_te { get; set; }
        public int type_k { get; set; }
        public decimal shape_leng { get; set; }
        public decimal shape_area { get; set; }
    }
}