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

        // GET api/CoolvisionTest
        public async Task<string> Get()
        {
            var _covidCountries = await Services.HttpRequests.GetCovidCountryData("Israel");

            if (_covidCountries.Count > 0)
                return "YES";
            return "NO";
        }

        // GET api/CoolvisionTest/China
        public async Task<string> Get(string country)
        {
            var _covidCountry = await Services.HttpRequests.GetCovidCountryData(country);
            var _skyscanner = await Services.HttpRequests.GetSkyscannerSearch(country);

            // update is covid flag
            _skyscanner.IsCovid = _covidCountry.Count > 0;

            var json = new JavaScriptSerializer().Serialize(_skyscanner);

            return json;
        }
    }
}