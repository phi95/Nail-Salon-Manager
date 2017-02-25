using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Nail_Salon_Manager.Models;
using Nail_Salon_Manager.ViewModel;

namespace Nail_Salon_Manager.Controllers
{
    public class InventoriesController : Controller
    {
        private ApplicationDbContext _context;

        public InventoriesController()
        {
            _context = new ApplicationDbContext();
        }

        public ViewResult Index()
        {
            var inventoryItems = _context.InventoryItems;
            return View(inventoryItems);
        }

        public ActionResult Details(int id)
        {
            var inventoryItem = _context.InventoryItems.SingleOrDefault(x => x.Id == id);

            if (inventoryItem == null)
                return HttpNotFound();

            return View(inventoryItem);
        }
    }
}