using Store.Model.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace Store.Web.ViewModels
{
    public class RegisterUserViewModel
    {

        public int ID { get; set; }

        [Required(ErrorMessage = "გთხოვთ შეავსოთ იუზერნეიმის ველი")]

        public string UserName { get; set; }
        public Employees Employees { get; set; }
        public int EmployeeId { get; set; }
        public string EmployeeFirstName { get; set; }

        [Required(ErrorMessage = "გთხოვთ შეავსოთ იუზერ როლის ველი")]
        public string UserRoleTitle { get; set; }

        [Required(ErrorMessage = "გთხოვთ შეავსოთ დასაქმებულის ემეილის ველი")]
        public string EmployeeEmail { get; set; }

        [Required(ErrorMessage = "გთხოვთ შეავსოთ პაროლის ველი")]
        [DataType(DataType.Password)]
        public string Password { get; set; }


        [Compare("Password", ErrorMessage = "პაროლი და გაიმეორეთ პაროლი არ ემთხვევა ერთმანეთს")]
        [Required(ErrorMessage = "გთხოვთ შეავსოთ გაიმეორეთ პაროლის ველი ველი")]
        [DataType(DataType.Password)]

       
        public string ConfirmPassword { get; set; }
        public bool IsActive { get; set; }

        
    }
}