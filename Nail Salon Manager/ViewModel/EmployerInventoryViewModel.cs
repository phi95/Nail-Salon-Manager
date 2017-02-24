using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nail_Salon_Manager.Models;

namespace Nail_Salon_Manager.ViewModel
{
    public class EmployerInventoryViewModel
    {
        public Employer Employer { get; set; }
        public List<InventoryItem> InventoryItems { get; set; }
    }
}