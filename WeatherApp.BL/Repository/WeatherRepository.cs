using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DataModel;
using WeatherApp.BL.Services;
using WeatherApp.DataModel.Models;

namespace WeatherApp.BL.Repository
{
    public interface IWeatherRepository
    {
        void AddWeather(string path, string fileName);

        IQueryable<Weather> GetWeather();
    }
    public class WeatherRepository : IWeatherRepository
    {
        private readonly Export _export;
        private readonly DataContext _context;
        public WeatherRepository(Export export, DataContext context)
        {
            _export = export;
            _context = context;
        }
        public void AddWeather(string path, string fileName)
        {
            var unpackPath = _export.Unpack(path);
            string[] files = Directory.GetFiles($"{unpackPath}/{fileName}", "*.xlsx");
            foreach (var file in files)
            {
                _export.ExcelExport(file);
            }
        }

        public IQueryable<Weather> GetWeather()
        {
            return _context.Weathers.OrderBy(p => p.TimeMeasuring);
        }
    }
}
