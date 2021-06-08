using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CoolvisionTest.Models
{
    public class ScannerModel
    {
        [JsonProperty("Places")]
        public List<Place> Places { get; set; }

        [JsonProperty("Quotes")]
        public List<Quote> Quotes { get; set; }

        [JsonProperty("Carriers")]
        public List<Carrier> Carriers { get; set; }
    }

    public class Place
    {
        [JsonProperty("Name")]
        public string Name { get; set; }

        [JsonProperty("CountryName")]
        public string CountryName { get; set; }

        [JsonProperty("CityName")]
        public string CityName { get; set; }
    }

    public class Quote
    {
        [JsonProperty("QuoteId")]
        public int QuoteId { get; set; }

        [JsonProperty("MinPrice")]
        public int MinPrice { get; set; }

        [JsonProperty("OutboundLeg")]
        public OutboundLeg OutboundLeg { get; set; }
    }


    public class OutboundLeg
    {
        [JsonProperty("CarrierIds")]
        public List<int> CarrierIds { get; set; }

        [JsonProperty("DepartureDate")]
        public DateTime DepartureDate { get; set; }
    }

    public class Carrier
    {
        [JsonProperty("CarrierId")]
        public int CarrierId { get; set; }

        [JsonProperty("Name")]
        public string Name { get; set; }
    }

    public class AirportInfo
    {
        [JsonProperty("Places")]
        public List<AirportPlace> AirportPlaces { get; set; }
    }

    public class AirportPlace
    {
        [JsonProperty("PlaceId")]
        public string PlaceId { get; set; }

        [JsonProperty("PlaceName")]
        public string PlaceName { get; set; }

        [JsonProperty("CountryName")]
        public string CountryName { get; set; }
    }
}