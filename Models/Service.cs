using System;
using System.Collections.Generic;

namespace Project3_Arrick_WebApp.Models
{
	public class Service
	{
		public Service(string type, string vID, string notes, string empID, double price, bool complete)
		{
			ServiceType = type;
			VID = vID;
			Notes = notes;
			AssignedEmployeeID = empID;
			Price = PriceList[type];
			Complete = complete;
   		}

		private static readonly string[] ServiceList = { "Oil Change and Filter", "Brake Pads", "Tire Rotation", "Fluids", "Detailing", "Spark Plugs", "Belt Replacement", "Battery Replacement", "Light Bulbs" };
       

		public string VID
		{
			get;
			set;
		}

		public string ServiceType
		{
			get;
			set;
		}

		public string Notes
		{
			get;
			set;
		}

		public static string[] getServiceList()
		{
			return ServiceList;
		}

		public string AssignedEmployeeID
		{
			get;
			set;
		}

		public double Price
		{
			get;
			set;
		}

		public bool Complete
		{
			get;
			set;
		}


		private static Dictionary<string, double> PriceList = PriceList= new Dictionary<string, double> {

                {"Oil Change and Filter", 50.25 },
                {"Brake Pads", 255.51},
                {"Tire Rotation", 100.15},
                {"Fluids", 70.10},
                {"Detailing", 330.05},
                {"Spark Plugs", 90.23},
                {"Belt Replacement", 80.99},
                {"Battery Replacement", 110.12},
                {"Light Bulbs", 60.90},
			    {"", 0.00},

            };

    }
}
