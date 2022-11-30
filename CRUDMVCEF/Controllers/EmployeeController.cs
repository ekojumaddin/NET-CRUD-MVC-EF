using CRUDMVCEF.Models;
using CRUDMVCEF.ViewModels;
using System.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUDMVCEF.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ModelEntities dbContext;

        public EmployeeController()
        {
            this.dbContext = new ModelEntities();
        }
        // GET: Employee  
        public ActionResult Index()
        {
            var employeeList = dbContext.Employees.Include(x => x.Department).ToList();
            return View(employeeList);
        }

        public ActionResult AddEmployees()
        {
            var employeeViewModel = new EmployeeViewModel()
            {
                Department = this.dbContext.Departments.ToList(),
                Employee = new Employees()
            };
            return View("EmployeeForm", employeeViewModel);
        }

        public ActionResult Edit(int id)
        {
            var employees = this.dbContext.Employees.FirstOrDefault(x => x.EmployeeId == id);
            var department = this.dbContext.Departments.ToList();

            var viewModel = new EmployeeViewModel()
            {
                Department = department,
                Employee = employees
            };
            return View("EmployeeForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Employees employee)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("AddEmployees", "Employee");
            }

            if (employee.EmployeeId == 0)
                this.dbContext.Employees.Add(employee);

            else
            {
                var employeesDb = this.dbContext.Employees.FirstOrDefault(x => x.EmployeeId == employee.EmployeeId);
                employeesDb.EmployeeName = employee.EmployeeName;
                employeesDb.EmployeeAddress = employee.EmployeeAddress;
                employeesDb.Phone = employee.Phone;
                employeesDb.Gender = employee.Gender;
                employeesDb.City = employee.City;
                employeesDb.Project = employee.Project;
                employeesDb.CompanyName = employee.CompanyName;
                employeesDb.PinCode = employee.PinCode;
                employeesDb.DepartmentId = employee.DepartmentId;
            }

            this.dbContext.SaveChanges();
            return RedirectToAction("Index", "Employee");
        }

        public ActionResult Delete(int id)
        {
            var employeeDb = this.dbContext.Employees.FirstOrDefault(x => x.EmployeeId == id);
            this.dbContext.Employees.Remove(employeeDb);
            this.dbContext.SaveChanges();

            return RedirectToAction("Index", "Employee");
        }
    }
}