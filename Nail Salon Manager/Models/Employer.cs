using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nail_Salon_Manager.Models
{
    public class Employer
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public List<Employee> Employees { get; set; }
        public List<byte> EmployeesId { get; set; }

        public List<InventoryItem> InventoryItems { get; set; }
        public List<byte> InventoryItemsId { get; set; }
    }
}