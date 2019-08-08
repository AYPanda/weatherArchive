using System;
using System.Collections.Generic;
using System.Text;

namespace DataModel.Models
{
    public class WeatherDirectionWind
    {
        public int WeatherDirectionWindId { get; set; }
        public Weather Weather { get; set; }
        public DirectionWind DirectionWind { get; set; }
    }
}
