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

        public ActionResult Details(int id)
        {
            var employee = _context.Employees.SingleOrDefault(x => x.Id == id);

            if (employee == null)
                return HttpNotFound();

            return View(employee);
        }

        [Route("employees/transactions/{id}")]
        public ActionResult Transactions(int id)
        {
            var employee = _context.Employees.SingleOrDefault(x => x.Id == id);

            if (employee == null)
                return HttpNotFound();

            return View(employee);
        }
    }
}