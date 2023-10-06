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
    public class RegisterGenreViewModel
    {
        public string searching { get; set; }
        public int ID { get; set; }
        [Required(ErrorMessage = "გთხოვთ შეიყვანოთ ჟანრის დასახელება")]
        public string Name { get; set; }


    }
}