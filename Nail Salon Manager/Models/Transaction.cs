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

        public DateTime Date { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid number")]
        public double Amount { get; set; }

        public string Description { get; set; }

        public Employee Employee { get; set; }

        [Display(Name = "Employee")]
        public string EmployeeId { get; set; }
    }
}