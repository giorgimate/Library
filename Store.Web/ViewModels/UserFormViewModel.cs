using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Store.Web.ViewModels
{
    public class UserFormViewModel
    {


        [Required(ErrorMessage = "fes")]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}