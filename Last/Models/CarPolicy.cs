using System;
using System.Collections.Generic;
using System.Text;

namespace Last.Models
{
    public class CarPolicy
    {
        public int CarId { get; set; }
        public int PoliceNo { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public System.DateTime UretimYili { get; set; }
        public string Plaka { get; set; }
    }
}
