using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Nail_Salon_Manager.Dtos
{
    public class EmployeeDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public DateTime? DOB { get; set; }

        [StringLength(255)]
        public string Address { get; set; }

        public List<byte> TransactionsId { get; set; }
    }
}