using System;
using System.Collections.Generic;

namespace Project3_Arrick_WebApp.Models
{
    public class Employee
    {
        public Employee()
        {
			cList = new List<Customer_info>();
        }

		public string Name
        {
            get;
            set;
        }

        public string empID
        {
            get;
            set;
        }
		public string Login
        {
            get;
            set;
        }
		public string Password
        {
            get;
            set;
        }
		public List<string> serviceByID
        {
            get;
            set;
        }
		public List<Customer_info> cList
        {
            get;
            set;
        }
    }
}
