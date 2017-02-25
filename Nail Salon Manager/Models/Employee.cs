using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Nail_Salon_Manager.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Date of Birth")]
        public DateTime? DOB { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        public List<Transaction> Transactions { get; set; }
        public List<byte> TransactionsId { get; set; }
    }
}