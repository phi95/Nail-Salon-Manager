using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nail_Salon_Manager.Models
{
    public class Transaction
    {
        public int Id { get; set; }
        public double Amount { get; set; }
        public string Description { get; set; }
    }
}