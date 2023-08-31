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
    public class RegisterAuthorViewModel
    {
        public string searching { get; set; }
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }


    }
}