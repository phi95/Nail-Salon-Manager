using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nail_Salon_Manager.Models;
using Nail_Salon_Manager.ViewModel;

namespace Nail_Salon_Manager.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext _context;

        public EmployeesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ViewResult Index()
        {
            var employees = _context.Employees;
            return View(employees);
        }

        public ViewResult New()
        {
            var viewModel = new EmployeeFormViewModel();
            return View("EmployeeForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var employee = _context.Employees.SingleOrDefault(x => x.Id == id);

            if (employee == null)
                return HttpNotFound();

            var viewModel = new EmployeeFormViewModel
            {
                Employee = employee
            };

            return View("EmployeeForm", viewModel);
        }

        public ActionResult Details(int id)
        {
            var employee = _context.Employees.SingleOrDefault(x => x.Id == id);

            if (employee == null)
                return HttpNotFound();

            return View(employee);
        }

        [HttpPost]
        public ActionResult Save(Employee employee)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new EmployeeFormViewModel
                {
                    Employee = employee
                };
                return View("EmployeeForm", viewModel);
            }

            if (employee.Id == 0)
                _context.Employees.Add(employee);
            else
            {
                var employeeInDb = _context.Employees.Single(x => x.Id == employee.Id);
                employeeInDb.Name = employee.Name;
                employeeInDb.DOB = employee.DOB;
                employeeInDb.Address = employee.Address;
            }
            _context.SaveChanges();

            return RedirectToAction("Index", "Employees");
        }

    }
}