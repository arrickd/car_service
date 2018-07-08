using System;
using System.Collections.Generic;

namespace Project3_Arrick_WebApp.Models
{
    public class Customer_info
    {

        public Customer_info(){
            Requests = new List<Request>();
        }

		public Customer_info(string fname,string lname,string address, string number, string id)
        {
			FName = fname;
			LName = lname;
			Address = address;
			Number = number;
			ID = id;

            Requests = new List<Request>();
        }

      //  private List<Request> Requests = new List<Request>();

        public string FName
        {
            get;
            set;
        }

        public string LName
        {
            get;
            set;
    
        }

        public string Address
        {
            get;
            set;
        }

        public string Number
        {
            get;
            set;
        }

        public string ID
        {
            get;
            set;
        }

        public  string Login
        {
            get;
            set;
        }

        public string Password
        {
            get;
            set;
        }
       // public List<Request> getActiveRequests()
        //{
         //   return Requests;
       // }

        public List<Request> Requests
        {
            get;
            set;
        }

    }
}
