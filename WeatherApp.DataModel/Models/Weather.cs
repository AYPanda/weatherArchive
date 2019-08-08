using System;
using System.Collections.Generic;
using System.Text;

namespace WeatherApp.DataModel.Models
{
    public class Weather
    {
        public int WeatherId { get; set; }
        public DateTime TimeMeasuring { get; set; }
        public double Temperature { get; set; }
        public double Humidity { get; set; }
        public double Td { get; set; }
        public int Atmosphere { get; set; }
        public string WeatherDirectionWind { get;set; }
        public int? SpeedWind { get; set; }
        public int? OverCast { get; set; }
        public int? H { get; set; }
        public string VW { get; set; }
        public string WeatherCondition { get; set; }

    }
}
