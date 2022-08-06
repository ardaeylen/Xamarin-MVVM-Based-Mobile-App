using System;
using System.Collections.Generic;
using System.Text;

namespace Last.Models
{
    public class Policy
    {
        public int PoliceNo { get; set; }
        public string SirketAdi { get; set; }
        public string PoliceUrunGrubu { get; set; }
        public DateTime TanzimTarihi { get; set; }
        public DateTime VadeTarihi { get; set; }
        public double PrimTutari { get; set; }
        public string Teminatlar { get; set; }
        public string Tip { get; set; }
        public double Borc { get; set; }
        public int UserId { get; set; }
    
    }
}
