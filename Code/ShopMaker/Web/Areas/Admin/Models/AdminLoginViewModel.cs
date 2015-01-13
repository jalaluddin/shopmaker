using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShopMaker.Web.Areas.Admin.Models
{
    public class AdminLoginViewModel
    {
        [Required]
        [Display(Name = "Your Email")]
        public string EmailAddress { get; set; }

        [Required]
        [Display(Name = "Your Password")]
        public string Password { get; set; }

        [Display(Name = "Remember me")]
        public bool Remember { get; set; }
    }
}