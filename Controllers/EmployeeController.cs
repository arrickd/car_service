using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project3_Arrick_WebApp.Models;

//note..
//Controller name must match View folder and action methods must mutch view file name.. haha

namespace Project3_Arrick_WebApp.Controllers
{
    public class EmployeeController : Controller
    {
		[HttpPost]
		public IActionResult Submit(IFormCollection collection)
        {
            
			string vid = Request.Form["vid"];
			string notes = Request.Form["ServiceNotes"];
			string[] list = Service.getServiceList();

			foreach (var x in list)
			{
				Debug.WriteLine(notes+" <<<<<<<<<<<<<<<<<<<<<<<<<<<<<<<");
				if (collection.ContainsKey(x)&&collection[x]!="false")
				{
					EmployeeQuerys.UpdateServices(vid, x, true);

				}
				else if(collection.ContainsKey(x) && collection[x] == "false")
				{
					EmployeeQuerys.UpdateServices(vid, x, false);
				}
			}

			if (notes != null && notes != "" && notes != " ")
			{
				EmployeeQuerys.UpdateRequestNotes(vid, notes);
			}

			Employee employee = new Employee();
            EmployeeLoginQuery.populateCustomerList(employee);

            foreach (var c in employee.cList)
            {

                CustomerLoginQuerys.populateRequests(c);
                CustomerLoginQuerys.populateServices(c);

            }
			                    
			return View("EmployeeLoggedIn",employee);
        } 
        
		public ActionResult login()
        {

            Employee employee = new Employee();
            EmployeeLoginQuery.populateCustomerList(employee);

            foreach (var c in employee.cList)
            {

                CustomerLoginQuerys.populateRequests(c);
                CustomerLoginQuerys.populateServices(c);

            }

			return View("EmployeeLoggedIn",employee);

        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}