using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Nail_Salon_Manager.Dtos
{
    public class TransactionDto
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Please enter valid number")]
        public double Amount { get; set; }

        public string Description { get; set; }

        public string EmployeeId { get; set; }

        public EmployeeDto Employee { get; set; }
    }
}