using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Pastures.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        [EmailAddress(ErrorMessage = "Поле {0} не является действительным адресом электронной почты.")]
        [Display(Name = "Email")]
        public string Email { get; set; }
        [Display(Name = "Роли")]
        public IList<string> Roles { get; set; }
    }
}