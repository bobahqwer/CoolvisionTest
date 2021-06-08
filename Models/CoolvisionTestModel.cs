using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolvisionTest.Models
{
    // Normalized model that will be used for 'our' API(s)/UI(s)
    public class CVModel
    {
        public List<CVQuotes> Quotes { get; set; }
        public bool IsCovid { get; set; }
    }

    public class CVQuotes
    {
        public List<CVPlace> Places { get; set; }
        public string CarrierName { get; set; }
        public DateTime DepartureDate { get; set; }
        public string DepartureDysplayDate { get; set; }
        public int MinPrice { get; set; }
    }

    public class CVPlace
    {
        public string CountryName { get; set; }
        public string CityName { get; set; }
        public string AirportName { get; set; }
    }
}