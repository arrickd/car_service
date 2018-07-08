using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Project3_Arrick_WebApp.Models;

//note..
//Controller name must match View folder and action methods must mutch view file name.. haha

namespace Project3_Arrick_WebApp.Controllers
{
    public class RequestController : Controller
    {
		[HttpPost]
        public IActionResult MakeRequest(bool oil, bool brakes,bool tires,bool fluids,bool detail,bool plugs,
                                         bool belts,bool battery,bool bulbs,string vid,string  make, 
		                                 string model, string year,string notes)
        {
			Request request = new Request(LoginController.customer.ID,make,model,year,vid,notes,"",DateTime.Today.ToString("d"));

			//requested services
			string oil1,brakes1,tires1,fluids1,detail1,plugs1,belts1,battery1,bulbs1;
			oil1 = (oil) ? "Oil Change and Filter" : "";
			brakes1 = (brakes) ? "Brake Pads" : "";
			tires1 = (tires) ? "Tire Rotation" : "";
			fluids1 = (fluids) ? "Fluids" : "";
			detail1 = (detail) ? "Detailing" : "";
			plugs1 = (plugs) ? "Spark Plugs" : "";
			belts1 = (belts) ? "Belt Replacement" : "";
			battery1 = (battery) ? "Battery Replacement" : "";
			bulbs1 = (bulbs) ? "Light Bulbs" : "";
			List<string> services = new List<string>
			{
				oil1,
				brakes1, 
				tires1, 
				fluids1, 
				detail1, 
				plugs1,
				belts1,
				battery1, 
				bulbs1 
			};
            //check which services customer selected and add to request
			foreach (string service in services)
			{
				if(service != ""){
					request.ManageServices.Add(new Service(service,vid,"","Jacob Smith",0.00,false)); // some fields to be edited by mechanic
				}
			}
            
			//make request query
			RequestQuerys.addRequest(request);
			RequestQuerys.addServices(request);
			return RedirectToAction("LoggedIn", "Login",new { Login = LoginController.customer.Login, Password = LoginController.customer.Password} );
        } 

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}