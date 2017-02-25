using Nail_Salon_Manager.Models;
using Nail_Salon_Manager.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nail_Salon_Manager.Controllers
{
    public class TransactionsController : Controller
    {
        private ApplicationDbContext _context;

        public TransactionsController()
        {
            _context = new ApplicationDbContext();
        }

        public ViewResult Index()
        {
            var transactions = _context.Transactions.Include(x => x.Employee);
            return View(transactions);
        }

        public ViewResult New()
        {
            var viewModel = new TransactionFormViewModel();
            return View("TransactionForm", viewModel);
        }

        public ActionResult Edit(int id)
        {
            var transaction = _context.Transactions.SingleOrDefault(x => x.Id == id);

            if (transaction == null)
                return HttpNotFound();

            var viewModel = new TransactionFormViewModel
            {
                Transaction = transaction,
                Employee = _context.Employees.SingleOrDefault(x => x.Id == transaction.EmployeeId)
            };

            return View("TransactionForm", viewModel);
        }

        [HttpPost]
        public ActionResult Save(Transaction transaction)
        {
            if(transaction.Id == 0)
            {
                transaction.Date = DateTime.Now;
                _context.Transactions.Add(transaction);
            }
            else
            {
                var transactionInDb = _context.Transactions.Single(x => x.Id == transaction.Id);
                transactionInDb.Date = transaction.Date;
                transactionInDb.Amount = transaction.Amount;
                transactionInDb.Description = transaction.Description;
                transactionInDb.EmployeeId = transaction.EmployeeId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Transactions");
        }

        public ActionResult Details(int id)
        {
            var transaction = _context.Transactions.SingleOrDefault(x => x.Id == id);

            if (transaction == null)
                return HttpNotFound();

            return View(transaction);
        }
    }
}