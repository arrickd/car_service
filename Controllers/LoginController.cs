using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Project3_Arrick_WebApp.Models;

namespace Project3_Arrick_WebApp.Controllers
{

	public class LoginController : Controller
    {
		public static Customer_info customer
        {
            get;
            set;
        }
        
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
         

        //VERIFIES LOGIN INFORMATION AND POPULATES PROFILES
        public ActionResult LoggedIn(string Login,string Password)
        {

			customer = new Customer_info();

            CustomerLoginQuerys.customerLogin(Login,Password,customer);
            CustomerLoginQuerys.populateRequests(customer);
            CustomerLoginQuerys.populateServices(customer);

            //if login fails
            if (customer.FName == null)
            {
                return RedirectToAction("Index", "Home");
            }

			ViewBag.CustomerID = customer.ID;
			ViewBag.Login = customer.Login;
			ViewBag.Password = customer.Password;
            return View("LoggedIn",customer);
            
        }
        
        public void EmployeeLoggedIn()
        {

            

        }
    }
}
