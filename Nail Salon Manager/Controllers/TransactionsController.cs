using Nail_Salon_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nail_Salon_Manager.Controllers
{
    public class TransactionsController : Controller
    {
        // GET: Transactions
        public ViewResult Index()
        {
            var transactions = GetTransactions();
            return View(transactions);
        }

        public ActionResult Edit(int id)
        {
            return Content("id =" + id);
        }

        public ActionResult Details(int id)
        {
            var transaction = GetTransactions().SingleOrDefault(x => x.Id == id);

            if (transaction == null)
                return HttpNotFound();

            return View(transaction);
        }

        private IEnumerable<Transaction> GetTransactions()
        {
            return new List<Transaction>
            {
                new Transaction {Id = 0, Amount = 15, Description = "first transaction" }
            };
        }
    }
}