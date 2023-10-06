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
    public class RegisterPositonViewModel
    {
        public string searching { get; set; }
        public int ID { get; set; }
        [Required(ErrorMessage = "გთხოვთ შეიყვანოთ პოზიციის დასახელება")]

        public string PositionTitle { get; set; }


    }
}