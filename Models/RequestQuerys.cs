using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;
using Project3_Arrick_WebApp.Controllers;
using Project3_Arrick_WebApp.Models;
namespace Project3_Arrick_WebApp.Models
{
    public class RequestQuerys
    {

		//normal login
		public static void addRequest(Request request)
		{

			var db = DBConnection.Instance();
			db.DatabaseName = "sql9235287";
			if (db.IsConnect())
			{
				string query = string.Format("INSERT INTO Request(CustomerId, Make, Model, Year, VID, Notes, Date) " +
				                             "VALUES('{0}','{1}','{2}','{3}','{4}','{5}','{6}')",
				                             LoginController.customer.ID,request.Make,request.Model,request.Year,request.VID,request.Notes,request.Date);
				var cmd = new MySqlCommand(query, db.Connection);
				cmd.ExecuteNonQuery();
               
				db.Close();
			}
		}

		public static void addServices(Request request)
        {
			foreach (Service s in request.ManageServices){
            var db = DBConnection.Instance();
            db.DatabaseName = "sql9235287";
				if (db.IsConnect())
				{                   
					string query = string.Format("INSERT INTO Service(ServiceType, VID, Notes, AssignedEmployeeID, Price, Complete) " +
												 "VALUES('{0}','{1}','{2}','{3}','{4}',FALSE)",
												 s.ServiceType, s.VID, s.Notes, s.AssignedEmployeeID, s.Price);
					var cmd = new MySqlCommand(query, db.Connection);
					cmd.ExecuteNonQuery();

					db.Close();
				}               
            }
        }
    }
}
