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
    public class RegisterShalveViewModel
    {
        public string searching { get; set; }
        public int ID { get; set; }
        public int Floor { get; set; }
        public int Room { get; set; }
        public string Shelf { get; set; }
        public string Section { get; set; }
        public string Row { get; set; }

    }
}