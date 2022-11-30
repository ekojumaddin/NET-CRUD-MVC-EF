using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CRUDMVCEF.Models
{
    public class Employees
    {
        [Key]
        public int EmployeeId { get; set; }

        [Display(Name = "Name")]
        public string EmployeeName { get; set; }

        public int PinCode { get; set; }
        public Departments Department { get; set; }

        [Display(Name = "Address")]
        public string EmployeeAddress { get; set; }

        [Display(Name = "Phone")]
        public string Phone { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "Project")]
        public string Project { get; set; }
        [Display(Name = "Company Name")]
        public string CompanyName { get; set; }
        
        [Display(Name = "Dept Name")]
        public int DepartmentId { get; set; }
    }
}