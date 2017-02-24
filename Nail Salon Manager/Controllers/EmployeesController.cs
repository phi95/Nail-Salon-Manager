using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nail_Salon_Manager.Models;


namespace Nail_Salon_Manager.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ViewResult Index(int? pageIndex, String sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Name";

            var employees = GetEmployees();
            return View(employees);
        }

        public ActionResult Edit(int id)
        {
            return Content("id =" + id);
        }

        public ActionResult Details(int id)
        {
            var employee = GetEmployees().SingleOrDefault(x => x.Id == id);

            if (employee == null)
                return HttpNotFound();

            return View(employee);
        }

        private IEnumerable<Employee> GetEmployees()
        {
            return new List<Employee>
            {
                new Employee {Id = 0, Name = "Nghia Le" }
            };
        }
    }
}