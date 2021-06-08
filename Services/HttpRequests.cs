using CoolvisionTest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace CoolvisionTest.Services
{
    public static class HttpRequests
    {
        #region Properties
        #endregion

        #region Public Methods

        public static async Task<CovidModel> GetCovidCountryData(string country = null)
        {
            var _url = Configuration.RapidAPIUrl.Covid;

            // in case country was specified
            if (!string.IsNullOrEmpty(country))
                _url += "?search=" + country;

            // get result from external API
            var _covidCountries = await sendGetRequest<CovidModel>(_url);

            return _covidCountries;
        }

        public static async Task<CVModel> GetSkyscannerSearch(string country)
        {
            var _datesTasks = new List<Task<ScannerModel>>();
            var _airports = await GetSkyscannerAirports(country);

            // get async skyscanner data for each airport of requered country
            foreach (var airport in _airports.AirportPlaces)
            {
                var _task = GetSkyscannerDates(airport.PlaceId);
                _datesTasks.Add(_task);
            }

            // wait till all async tasks is ready
            await Task.WhenAll(_datesTasks);

            // parse the serach results
            var _output = parseSearchData(_datesTasks);
            return _output;
        }

        public static async Task<AirportInfo> GetSkyscannerAirports(string country)
        {
            // example of possible exception throw for API users
            if (string.IsNullOrEmpty(country))
                throw new Exception("The country name is requered parameter");

            var _url = $"{Configuration.RapidAPIUrl.SkyscannerPlace}/{Configuration.SearchDefaults.Country}/{Configuration.SearchDefaults.Currency}/{Configuration.SearchDefaults.Locale}/?query={country}";

            // get result from external API
            var _airports = await sendGetRequest<AirportInfo>(_url);
            return _airports;
        }

        public static async Task<ScannerModel> GetSkyscannerDates(string airport)
        {
            var _url = $"{Configuration.RapidAPIUrl.Skyscanner}/{Configuration.SearchDefaults.Country}/{Configuration.SearchDefaults.Currency}/{Configuration.SearchDefaults.Locale}/{Configuration.SearchDefaults.OriginPlace}" +
                $"/{airport}/anytime";

            // get result from external API
            var _covidCountries = await sendGetRequest<ScannerModel>(_url);

            return _covidCountries;
        }

        #endregion

        #region Private Methods

        private static async Task<T> sendGetRequest<T>(string url) where T : class
        {
            try
            {
                var _client = new HttpClient();
                var _uri = new Uri(url);
                var _request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = _uri,
                    Headers =
                {
                    { "x-rapidapi-key", Configuration.RapidAPIKey },
                    { "x-rapidapi-host", _uri.Host },
                },
                };
                using (var _response = await _client.SendAsync(_request))
                {
                    _response.EnsureSuccessStatusCode();
                    return _response.Content.ReadAsAsync<T>().Result;
                }

            }
            catch (Exception ex)
            {
                // TODO: add async write to logs
                var _exMessage = ex.Message;
                return null;
                //throw;
            }
        }

        private static CVModel parseSearchData(List<Task<ScannerModel>> datesTasks) 
        {
            var _output = new CVModel { Quotes = new List<CVQuotes>() };

            // gather data
            foreach (var datesTask in datesTasks)
            {
                var _result = datesTask.Result;

                if (_result == null) continue; // case when no flights from aitport A to airport B

                var _quotes = _result.Quotes.Select(q =>
                {
                    return new CVQuotes
                    {
                        MinPrice = q.MinPrice,
                        DepartureDate = q.OutboundLeg.DepartureDate,
                        DepartureDysplayDate = q.OutboundLeg.DepartureDate.ToString("yyyy-MM-dd"), // TODO: move mask to config
                        CarrierName = String.Join(",", _result.Carriers.Where(c => q.OutboundLeg.CarrierIds.Contains(c.CarrierId)).Select(c => c.Name)),
                        Places = _result.Places.Select(p => new CVPlace
                        {
                            AirportName = p.Name,
                            CityName = p.CityName,
                            CountryName = p.CountryName
                        }).ToList()
                    };
                });
                _output.Quotes.AddRange(_quotes);
            }

            // order data
            _output.Quotes = _output.Quotes.OrderBy(q => q.DepartureDate).ToList();

            return _output;
        }

        #endregion

    }
}