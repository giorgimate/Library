using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.Ajax.Utilities;
using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace Store.Web.ViewModels
{
    public class RegisterAuthorViewModel
    {
        public string searching { get; set; }
        public int ID { get; set; }
        [Required(ErrorMessage = "გთხოვთ შეიყვანოთ ავტორის სახელი")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "გთხოვთ შეიყვანოთ ავტორის გვარი")]
        public string LastName { get; set; }


    }
}