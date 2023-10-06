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
    public class RegisterShalveViewModel
    {
        public string searching { get; set; }
        public int ID { get; set; }
        [Required(ErrorMessage = "გთხოვთ შეიყვანოთ სართულის ნომერი")]
        public int Floor { get; set; }
        [Required(ErrorMessage = "გთხოვთ შეიყვანოთ ოთახის ნომერი")]

        public int Room { get; set; }
        [Required(ErrorMessage = "გთხოვთ შეიყვანოთ თაროს დასახელება")]

        public string Shelf { get; set; }
        [Required(ErrorMessage = "გთხოვთ შეიყვანოთ სექციის დასახელება")]

        public string Section { get; set; }
        [Required(ErrorMessage = "გთხოვთ შეიყვანოთ რიგის დასახელება")]

        public string Row { get; set; }

    }
}