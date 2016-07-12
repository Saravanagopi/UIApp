using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UIApp.Models
{
    public class Vehicle
    {
        private string _number;
        public string vin
        {
            get { return _number; }
            set { _number = value; }
        }

        public List<VehicleVM> fcd { get; set; }
    }
}