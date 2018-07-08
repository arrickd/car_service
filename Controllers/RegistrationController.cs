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
    public class RegistrationController : Controller
    {

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult RegisterForm()
        {

            ViewData["uesrTaken"] = TempData["message"];
            return View("RegisterForm");
        }

        public IActionResult Redirect()
        {
            return RedirectToAction("Index","Home");
        }


        public ActionResult Register(string FName, string LName, string Address, 
		                             string Number, string Login, string Password )
        {

            Customer_info customer = new Customer_info();
            TempData["message"] = "";

            //CHECK FOR USER TAKEN
            var db = DBConnection.Instance();
            db.DatabaseName = "sql9235287";
            if (db.IsConnect())
            {
                
                string query = string.Format("SELECT * FROM Customer_info WHERE Login='{0}'",Login);
                var cmd = new MySqlCommand(query, db.Connection);
                cmd.CommandType = System.Data.CommandType.Text;
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if (reader.GetString(5) == Login)
                    {
                        reader.Close();
                        TempData["message"] = "USERNAME TAKEN";
                        return RedirectToAction("RegisterForm");
                    }
                }

                db.Close();
            }

            //RETURN CURRENT ID COUNT FOR NEW ID ASSIGNMENT
            int ID =1;
            db = DBConnection.Instance();
            db.DatabaseName = "sql9235287";
            if (db.IsConnect())
            {

                string query = "SELECT * FROM ID_Count";
                var cmd = new MySqlCommand(query, db.Connection);
                ID += (int)cmd.ExecuteScalar();

                db.Close();
            }

            //REGISTER NEW USER
            db = DBConnection.Instance();
            db.DatabaseName = "sql9235287";
            if (db.IsConnect())
            {
                string insert = string.Format("INSERT INTO Customer_info(FName, LName, Address, Number, ID, Login, Password) VALUES ('{0}','{1}','{2}','{3}','{4}','{5}','{6}')", FName, LName, Address, Number, ID, Login, Password);

                var cmd = new MySqlCommand(insert, db.Connection);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();

                db.Close();
            }

            //UPDATE CURRENT ID COUNT IN TABLE
            db =DBConnection.Instance();
            db.DatabaseName = "sql9235287";
            if (db.IsConnect())
            {
                string update = string.Format("UPDATE ID_Count SET count='{0}'", ID);

                var cmd = new MySqlCommand(update, db.Connection);
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.ExecuteNonQuery();

                db.Close();
            }


            return RedirectToAction("Redirect");

        }
    }
}
