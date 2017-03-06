using Nail_Salon_Manager.Models;
using Nail_Salon_Manager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Nail_Salon_Manager.Controllers
{
    public class InventoryItemsController : Controller
    {
        private ApplicationDbContext _context;

        public InventoryItemsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ViewResult New()
        {
            return View("InventoryItemForm");
        }

        [HttpPost]
        public ActionResult Save(InventoryItem inventoryItem)
        {
            if (inventoryItem.Id == 0)
            {
                _context.InventoryItems.Add(inventoryItem);
            }
            else
            {
                var inventoryItemInDb = _context.InventoryItems.Single(x => x.Id == inventoryItem.Id);
                inventoryItemInDb.Name = inventoryItem.Name;
                inventoryItemInDb.Cost = inventoryItem.Cost;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "InventoryItems");
        }
    }
}