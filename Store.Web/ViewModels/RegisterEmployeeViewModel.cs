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
    public class RegisterEmployeeViewModel
    {
        public string searching { get; set; }
        public int ID { get; set; }
        public int PositionID { get; set; }
        [Required(ErrorMessage = "გთხოვთ შეიყვანოთ თანამშრომლის სახელი")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "გთხოვთ შეიყვანოთ თანამშრომლის გვარი")]
        public string LastName { get; set; }
        public bool RegisterUserWithoutEmployee {get; set;}
        [Required(ErrorMessage = "გთხოვთ შეიყვანოთ თანამშრომლის მისამართი")]
        public string Address { get; set; }
        public bool IsChecked { get; set; }
        [Required(ErrorMessage = "გთხოვთ შეიყვანოთ თანამშრომლის მეილი")]
        public string Email { get; set; }
        [Required(ErrorMessage = "გთხოვთ შეიყვანოთ თანამშრომლის ტელეფონის ნომერი")]
        public string PhoneNumber { get; set; }
        public DateTime? HireDate { get; set; }
        [Required(ErrorMessage = "გთხოვთ შეიყვანოთ თანამშრომლის ხელფასი")]
        [Range(1, int.MaxValue, ErrorMessage = "ხელფასი უნდა იყოს 0-ზე მეტი")]

        public int Sallary { get; set; }
        public Users User { get; set; }
        public RegisterUserViewModel RegisterUserViewModell { get; set; }
        public List<Positions> Positions { get; set; }
        public List<EmployeePositions> EmployeePositions { get; set; }


    }
}