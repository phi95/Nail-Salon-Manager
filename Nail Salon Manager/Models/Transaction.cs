using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nail_Salon_Manager.Models
{
    public class Transaction
    {
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public double Amount { get; set; }

        public string Description { get; set; }

        public Employee Employee { get; set; }

        [Required]
        [Display(Name = "Employee")]
        public string EmployeeId { get; set; }
    }
}