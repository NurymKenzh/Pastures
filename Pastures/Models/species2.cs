﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pastures.Models
{
    [Table("species2", Schema = "public")]
    public class species2
    {
        public int gid { get; set; }
        public int objectid { get; set; }
        public string name_obl { get; set; }
        public int cd { get; set; }
        public string name { get; set; }
        public decimal shape_leng { get; set; }
        public decimal shape_area { get; set; }
        public string kato { get; set; }

        [Display(Name = "Всего голов")]
        public int? totalgoals { get; set; }

        [Display(Name = "КРС")]
        public int? cattle { get; set; }

        [Display(Name = "Лошади")]
        public int? horses { get; set; }

        [Display(Name = "Овцы")]
        public int? smallcattle { get; set; }

        [Display(Name = "Верблюды")]
        public int? camels { get; set; }

        [Display(Name = "Всего условных голов (в пересчете на овец)")]
        public decimal? conditional { get; set; }

        [Display(Name = "По состоянию на")]
        public string date { get; set; }

        [Display(Name = "Источник")]
        public int? source { get; set; }

        [Display(Name = "Численность населения")]
        public int? population { get; set; }

        [Display(Name = "Площадь патбищ, га")]
        public int? pastures { get; set; }
    }
}