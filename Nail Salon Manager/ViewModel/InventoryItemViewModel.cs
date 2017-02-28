using Nail_Salon_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nail_Salon_Manager.ViewModel
{
    public class InventoryItemViewModel
    {
        public InventoryItem InventoryItem { get; set; }
        public string Title
        {
            get
            {
                if (InventoryItem != null && InventoryItem.Id != 0)
                    return "Edit Item";
                return "New Inventory Item";
            }
        }
    }
}