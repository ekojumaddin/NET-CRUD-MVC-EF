using CRUDMVCEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CRUDMVCEF.ViewModels
{
    public class EmployeeViewModel
    {
        public IEnumerable<Departments> Department { get; set; }
        public Employees Employee { get; set; }
    }
}