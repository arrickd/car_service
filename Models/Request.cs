using System;
using System.Collections.Generic;

namespace Project3_Arrick_WebApp.Models
{
    public class Request
    {
        public Request(string cid, string make, string model, string year, string vid, string notes,string snotes, String date)
        {
            CustomerID = cid;
            Make = make;
            Model = model;
            Year = year;
            VID = vid;
            Notes = notes;
			ServiceNotes = snotes;
			Date = date;

            ManageServices = new List<Service>();
        }

       // private List<Service> ServicesList = new List<Service>();

        public string CustomerID
        {
            get;
            set;
        }
        public string Make
        {
            get;
            set;
        }
        public string Model
        {
            get;
            set;
        }

        public string Year
        {
            get;
            set;
        }
        public string VID
        {
            get;
            set;
        }
        public List<Service> ManageServices
        {
            get;
            set;
        }
        public string Notes
        {
            get;
            set;
        }
		public string ServiceNotes
        {
            get;
            set;
        }
		public String Date
        {
            get;
            set;
        }
        public string complete()
        {
            bool complete=true;
            foreach (var s in ManageServices)
            {
                if (!s.Complete) { complete = false; }
            }

            if(complete){

                return "COMPLETE";
            }

            return "ACTIVE";

        }

        public double total()
        {
            double total=0;
            foreach(var s in ManageServices){
                total += s.Price;
            }

            return total;
        }

    }
}
