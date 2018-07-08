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
    public class EmployeeLoginQuery
    {

        //normal login
        public static void employeeLogin(string Login, string Password, Employee employee)
        {

            var db = DBConnection.Instance();
            db.DatabaseName = "sql9235287";
            if (db.IsConnect())
            {
				string query = string.Format("SELECT * FROM Employee WHERE Login='{0}' AND Password='{1}'", Login, Password);
                var cmd = new MySqlCommand(query, db.Connection);
                cmd.CommandType = System.Data.CommandType.Text;
                var reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    //arange like table
					employee.Name = reader.GetString(0);
					employee.empID = reader.GetString(1);

                }

                db.Close();
            }
            
                
         }

            //POPULATE REQUESTS
		public static void populateCustomerList(Employee employee)
        {
			var db = DBConnection.Instance();
            db.DatabaseName = "sql9235287";
            if (db.IsConnect())
            {
                string query = string.Format("SELECT * FROM Customer_info");
                var cmd = new MySqlCommand(query, db.Connection);
                cmd.CommandType = System.Data.CommandType.Text;
                var reader = cmd.ExecuteReader();


                while (reader.Read())
                {
					employee.cList.Add(new Customer_info(reader.GetString(0),reader.GetString(1),reader.GetString(2),
					                                     reader.GetString(3),reader.GetString(4)));

                }

                db.Close();
            }
         }
    }
}
