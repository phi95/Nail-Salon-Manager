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
        // GET: Inventories
        public ViewResult Index()
        {
            var inventoryItems = GetInventories();

            return View(inventoryItems);
        }

        public ActionResult Details(int id)
        {
            var inventoryItem = GetInventories().SingleOrDefault(x => x.Id == id);

            if (inventoryItem == null)
                return HttpNotFound();

            return View(inventoryItem);
        }

        private IEnumerable<InventoryItem> GetInventories()
        {
            return new List<InventoryItem>
            {
                new InventoryItem {Id = 0, Name = "Acetone" },
                new InventoryItem {Id = 1, Name = "Paint" }
            };
        }
    }
}