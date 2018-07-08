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
    public class CustomerLoginQuerys
    {

        //normal login
        public static void customerLogin(string Login, string Password, Customer_info customer)
        {

            var db = DBConnection.Instance();
            db.DatabaseName = "sql9235287";
            if (db.IsConnect())
            {
                string query = string.Format("SELECT * FROM Customer_info WHERE Login='{0}' AND Password='{1}'", Login, Password);
                var cmd = new MySqlCommand(query, db.Connection);
                cmd.CommandType = System.Data.CommandType.Text;
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    customer.FName = reader.GetString(0);
                    customer.LName = reader.GetString(1);
                    customer.Address = reader.GetString(2);
                    customer.Number = reader.GetString(3);
                    customer.ID = reader.GetString(4);
                    customer.Login = reader.GetString(5);
                    customer.Password = reader.GetString(6);
                }

                db.Close();
            }
            
                
            }

            //POPULATE REQUESTS
        public static void populateRequests(Customer_info customer)
        {
            var db = DBConnection.Instance();
            db.DatabaseName = "sql9235287";
            if (db.IsConnect())
            {
                string query = string.Format("SELECT * FROM Request WHERE CustomerID='{0}'", customer.ID);
                var cmd = new MySqlCommand(query, db.Connection);
                cmd.CommandType = System.Data.CommandType.Text;
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    customer.Requests.Add(new Request(reader.GetString(0), reader.GetString(1),
                                                      reader.GetString(2), reader.GetString(3),
					                                  reader.GetString(4), reader.GetString(5),
					                                  reader.GetString(6),reader.GetString(7)));
                }

                db.Close();
            }
         }

        //POPULATE SERVICES 
        public static void populateServices(Customer_info customer)
        {
			foreach (Request req in customer.Requests){
                var db = DBConnection.Instance();
                db.DatabaseName = "sql9235287";

				if (db.IsConnect())
				{               
					string query = string.Format("SELECT * FROM Service WHERE VID='{0}'", req.VID);
					var cmd = new MySqlCommand(query, db.Connection);
					cmd.CommandType = System.Data.CommandType.Text;
					var reader = cmd.ExecuteReader();
                    
					while (reader.Read())
					{
						req.ManageServices.Add(new Service(reader.GetString(0), reader.GetString(1),
														   reader.GetString(2), reader.GetString(3),
						                                   reader.GetFloat(4),reader.GetBoolean(5)));
					}

					db.Close();
				}
            }
        }
    }
}
