﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pastures.Models
{
    [Table("STypes", Schema = "public")]
    public class SType
    {
        public int Id { get; set; }

        [Display(Name = "Код")]
        public int Code { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; }
    }
}