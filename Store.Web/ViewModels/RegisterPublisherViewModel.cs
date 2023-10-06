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
    public class RegisterPublisherViewModel
    {
        public string searching { get; set; }
        public int ID { get; set; }
        [Required(ErrorMessage = "გთხოვთ შეიყვანოთ გამომცემელობის სახელი")]

        public string Name { get; set; }
        [Required(ErrorMessage = "გთხოვთ შეიყვანოთ გამომცემელობის მისამართი")]

        public string Address { get; set; }
        [Required(ErrorMessage = "გთხოვთ შეიყვანოთ გამომცემელობის ტელეფონის ნომერი")]

        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "გთხოვთ შეიყვანოთ გამომცემელობის მეილი")]
        [RegularExpression(@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$", ErrorMessage = "გთხოვთ მიუთითოთ სწორი ელ-ფოსტის მისამართი")]

        public string Email { get; set; }


    }
}