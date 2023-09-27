using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.Ajax.Utilities;
using Store.Model.Models;
using System;
using System.Collections.Generic;
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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool RegisterUserWithoutEmployee {get; set;}
        public string Address { get; set; }
        public bool IsChecked { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime? HireDate { get; set; }
        public int Sallary { get; set; }
        public Users User { get; set; }
        public RegisterUserViewModel RegisterUserViewModell { get; set; }
        public List<Positions> Positions { get; set; }
        public List<EmployeePositions> EmployeePositions { get; set; }


    }
}