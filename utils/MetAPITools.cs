﻿using System.Collections.ObjectModel;

namespace Backend.utils
{
    public static class MetAPITools
    {
        // This collection is sort of bloated, as some of these items can be removed, check out
        // https://api.met.no/weatherapi/weathericon/2.0/documentation.
        public static readonly Collection<string> ValidSymbolCodes = new()
        {
            "clearsky_day",
            "cloudy",
            "fair_day",
            "fog",
            "heavyrain",
            "heavyrainandthunder",
            "heavyrainshowers_day",
            "heavyrainshowersandthunder_day",
            "heavysleet",
            "heavysleetandthunder",
            "heavysleetshowers_day",
            "heavysleetshowersandthunder_day",
            "heavysnow",
            "heavysnowandthunder",
            "heavysnowshowers_day",
            "heavysnowshowersandthunder_day",
            "lightrain",
            "lightrainandthunder",
            "lightrainshowers_day",
            "lightrainshowersandthunder_day",
            "lightsleet",
            "lightsleetandthunder",
            "lightsleetshowers_day",
            "lightsnow",
            "lightsnowandthunder",
            "lightsnowshowers_day",
            "lightssleetshowersandthunder_day",
            "lightssnowshowersandthunder_day",
            "partlycloudy_day",
            "rain",
            "rainandthunder",
            "rainshowers_day",
            "rainshowersandthunder_day",
            "sleet",
            "sleetandthunder",
            "sleetshowers_day",
            "sleetshowersandthunder_day",
            "snow",
            "snowandthunder",
            "snowshowers_day",
            "snowshowersandthunder_day",
            "clearsky_night",
            "cloudy_night",
            "fair_night",
            "heavyrain_night",
            "heavyrainandthunder_night",
            "heavyrainshowers_night",
            "heavyrainshowersandthunder_night",
            "heavysleet_night",
            "heavysleetandthunder_night",
            "heavysleetshowers_night",
            "heavysleetshowersandthunder_night",
            "heavysnow_night",
            "heavysnowandthunder_night",
            "heavysnowshowers_night",
            "heavysnowshowersandthunder_night",
            "lightrain_night",
            "lightrainandthunder_night",
            "lightrainshowers_night",
            "lightrainshowersandthunder_night",
            "lightsleet_night",
            "lightsleetandthunder_night",
            "lightsleetshowers_night",
            "lightsnow_night",
            "lightsnowandthunder_night",
            "lightsnowshowers_night",
            "lightssleetshowersandthunder_night",
            "lightssnowshowersandthunder_night",
            "partlycloudy_night",
            "rain_night",
            "rainandthunder_night",
            "rainshowers_night",
            "rainshowersandthunder_night",
            "sleetshowers_night",
            "sleetshowersandthunder_night",
            "snowshowers_night",
            "snowshowersandthunder_night",
            "clearsky_polartwilight",
            "cloudy_polartwilight",
            "fair_polartwilight",
            "heavyrain_polartwilight",
            "heavyrainandthunder_polartwilight",
            "heavyrainshowers_polartwilight",
            "heavyrainshowersandthunder_polartwilight",
            "heavysleet_polartwilight",
            "heavysleetandthunder_polartwilight",
            "heavysleetshowers_polartwilight",
            "heavysleetshowersandthunder_polartwilight",
            "heavysnow_polartwilight",
            "heavysnowandthunder_polartwilight",
            "heavysnowshowers_polartwilight",
            "heavysnowshowersandthunder_polartwilight",
            "lightrain_polartwilight",
            "lightrainandthunder_polartwilight",
            "lightrainshowers_polartwilight",
            "lightrainshowersandthunder_polartwilight",
            "lightsleet_polartwilight",
            "lightsleetandthunder_polartwilight",
            "lightsleetshowers_polartwilight",
            "lightsnow_polartwilight",
            "lightsnowandthunder_polartwilight",
            "lightsnowshowers_polartwilight",
            "lightssleetshowersandthunder_polartwilight",
            "lightssnowshowersandthunder_polartwilight",
            "partlycloudy_polartwilight",
            "rain_polartwilight",
            "rainandthunder_polartwilight",
            "rainshowers_polartwilight",
            "rainshowersandthunder_polartwilight",
            "sleetshowers_polartwilight",
            "sleetshowersandthunder_polartwilight",
            "snowshowers_polartwilight",
            "snowshowersandthunder_polartwilight"
        };
    }
}