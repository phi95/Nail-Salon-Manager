using Nail_Salon_Manager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Nail_Salon_Manager.ViewModel
{
    public class EmployeeFormViewModel
    {
        public Employee Employee { get; set; }
        public string Title
        {
            get
            {
                if (Employee != null && Employee.Id != 0)
                    return "Edit Employee";
                return "New Employee";
            }
        }
    }
}