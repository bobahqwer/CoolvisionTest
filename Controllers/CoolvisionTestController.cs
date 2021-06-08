using CoolvisionTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace CoolvisionTest.Controllers
{
    public class CoolvisionTestController : ApiController
    {
        #region Public Methods

        // GET api/CoolvisionTest
        public async Task<string> Get()
        {
            var _output = await getCountriesData("anytime");
            
            var json = new JavaScriptSerializer().Serialize(_output);
            return json;
        }

        // GET api/CoolvisionTest/21-09-01
        public async Task<string> Get(string date)
        {
            var _output = await getCountriesData(date);

            var json = new JavaScriptSerializer().Serialize(_output);
            return json;
        }

        // GET api/CoolvisionTest/21-09-01/France
        public async Task<string> Get(string date, string country)
        {
            var _output = await getCountryData(country, date);

            var json = new JavaScriptSerializer().Serialize(_output);

            return json;
        }

        #endregion

        #region Private Methods

        // Get multiple countries data
        private async Task<List<CVModel>> getCountriesData(string date) 
        {
            var _output = new List<CVModel>();

            // get data models for each country from the list
            foreach (var Country in "France,United Kingdom,United States,Australia".Split(','))
            {
                var _data = await getCountryData(Country.Trim(), date);
                _output.Add(_data);
            }

            // order by Covid Active cases, internal data ordered by date and price field
            return _output.OrderBy(m => m.Country.CovidActiveCases).ToList();
        }

        // United Kindoms noe exist in one API, its exist as UK --> added data sources "addaptation table"
        private Dictionary<string, string> covidReplacingValues = new Dictionary<string, string> { { "United Kingdom", "UK" }, { "United States", "USA" } };

        // Get single country data
        private async Task<CVModel> getCountryData(string country, string date)
        {
            // get skyscanner search data
            var _skyscanner = await Services.HttpRequests.GetSkyscannerSearch(country, date);

            // update country name upon to Covid API service "addaptation table"
            if (this.covidReplacingValues.ContainsKey(country))
                country = this.covidReplacingValues[country];

            // get covid data
            var _covidCountry = await Services.HttpRequests.GetCovidCountryData(country);

            // update country name and Covid data of current model
            _skyscanner.Country = new CVCountry();
            _skyscanner.Country.CountryName = country;
            _skyscanner.Country.CovidActiveCases = _covidCountry.Countries.FirstOrDefault(c => c.CountryName.Equals(country)).Cases.Active;

            return _skyscanner;
        }

        #endregion
    }
}