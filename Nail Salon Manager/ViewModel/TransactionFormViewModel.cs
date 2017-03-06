using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Nail_Salon_Manager.Models;

namespace Nail_Salon_Manager.ViewModel
{
    public class TransactionFormViewModel
    {
        public Transaction Transaction { get; set; }
        public Employee Employee { get; set; }
        public string Title = "New Transaction";

        public IEnumerable<Employee> Employees { get; set; }
    }
}