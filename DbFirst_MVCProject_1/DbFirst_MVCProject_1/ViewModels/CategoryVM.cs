using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DbFirst_MVCProject_1.Models;

namespace DbFirst_MVCProject_1.ViewModels
{
    public class CategoryVM
    {
        // veriyi pekatledik.
        public List<Category> Categories { get; set; }
        public List<Employee> Employees { get; set; }
        public List<Product> Products { get; set; }
    }
}