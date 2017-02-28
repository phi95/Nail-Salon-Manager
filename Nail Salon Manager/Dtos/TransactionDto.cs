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
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public double Amount { get; set; }

        public string Description { get; set; }
        public int EmployeeId { get; set; }
        public EmployeeDto Employee { get; set; }
    }
}