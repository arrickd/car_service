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
    public class EmployeeQuerys
    {

		//normal login
		public static void UpdateServices(string VID,string service,bool check)
		{

			var db = DBConnection.Instance();
			db.DatabaseName = "sql9235287";
			if (db.IsConnect())
			{
                
				string query = "";
				if(check){
				    query = string.Format("UPDATE Service SET Complete='1' WHERE VID='{0}' AND ServiceType='{1}'",VID,service);
				}
				else if(!check){
					query = string.Format("UPDATE Service SET Complete='0' WHERE VID='{0}' AND ServiceType='{1}'", VID, service);

				}
				var cmd = new MySqlCommand(query, db.Connection);
				cmd.ExecuteNonQuery();
               
				db.Close();
			}
		}

		public static void UpdateRequestNotes(string VID, string notes)
        {

            var db = DBConnection.Instance();
            db.DatabaseName = "sql9235287";
            if (db.IsConnect())
            {
				string query = string.Format("UPDATE Request SET ServiceNotes='{0}' WHERE VID='{1}'", notes, VID);
                var cmd = new MySqlCommand(query, db.Connection);
                cmd.ExecuteNonQuery();

                db.Close();
            }
        }
    }
}
