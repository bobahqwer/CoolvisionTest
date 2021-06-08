using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace CoolvisionTest.Services
{
    public static class Configuration
    {
        // !!! Exist configuration builder that convert app.config keys to hierarchical classes. For now I used a manual approach.

        private static string countriesList;
        public static string CountriesList
        {
            get
            {
                if (string.IsNullOrEmpty(countriesList))
                    countriesList = WebConfigurationManager.AppSettings["CoolvisionTest.CountriesList"];
                return countriesList;
            }
        }

        #region Search defaults

        public static class SearchDefaults
        {
            private static string country;
            public static string Country
            {
                get
                {
                    if (string.IsNullOrEmpty(country))
                        country = WebConfigurationManager.AppSettings["CoolvisionTest.SearchDefaults.Country"];
                    return country;
                }
            }

            private static string originPlace;
            public static string OriginPlace
            {
                get
                {
                    if (string.IsNullOrEmpty(originPlace))
                        originPlace = WebConfigurationManager.AppSettings["CoolvisionTest.SearchDefaults.OriginPlace"];
                    return originPlace;
                }
            }

            private static string currency;
            public static string Currency
            {
                get
                {
                    if (string.IsNullOrEmpty(currency))
                        currency = WebConfigurationManager.AppSettings["CoolvisionTest.SearchDefaults.Currency"];
                    return currency;
                }
            }

            private static string locale;
            public static string Locale
            {
                get
                {
                    if (string.IsNullOrEmpty(locale))
                        locale = WebConfigurationManager.AppSettings["CoolvisionTest.SearchDefaults.Locale"];
                    return locale;
                }
            }
        }

        #endregion

        #region Rapid API

        private static string rapidAPIKey;
        public static string RapidAPIKey
        {
            get
            {
                if (string.IsNullOrEmpty(rapidAPIKey))
                    rapidAPIKey = WebConfigurationManager.AppSettings["CoolvisionTest.RapidAPIKey"];
                return rapidAPIKey;
            }
        }

        public static class RapidAPIUrl
        {
            private static string covid;
            public static string Covid
            {
                get
                {
                    if (string.IsNullOrEmpty(covid))
                        covid = WebConfigurationManager.AppSettings["CoolvisionTest.RapidAPIURL.Covid"];
                    return covid;
                }
            }

            private static string skyscanner;
            public static string Skyscanner
            {
                get
                {
                    if (string.IsNullOrEmpty(skyscanner))
                        skyscanner = WebConfigurationManager.AppSettings["CoolvisionTest.RapidAPIURL.Skyscanner"];
                    return skyscanner;
                }
            }

            private static string skyscannerPlace;
            public static string SkyscannerPlace
            {
                get
                {
                    if (string.IsNullOrEmpty(skyscannerPlace))
                        skyscannerPlace = WebConfigurationManager.AppSettings["CoolvisionTest.RapidAPIURL.SkyscannerPlace"];
                    return skyscannerPlace;
                }
            }
        }

        #endregion
    }
}