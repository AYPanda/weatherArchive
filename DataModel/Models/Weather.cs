using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Models
{
    public class Weather
    {
        public int WeatherId { get; set; }
        public DateTime TimeMeasuring { get; set; }
        public double Temperature { get; set; }
        public int Humidity { get; set; }
        public double Td { get; set; }
        public int Atmosphere { get; set; }
        public ICollection<WeatherDirectionWind> WeatherDirectionWinds { get;set; }
        public int SpeedWind { get; set; }
        public int OverCast { get; set; }
        public int H { get; set; }
        public int? VW { get; set; }
        public WeatherCondition WeatherCondition { get; set; }
    }
}
