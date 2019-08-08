using System;
using System.IO;
using System.IO.Compression;
using NPOI.XSSF.UserModel;
using DataModel;
using System.Linq;
using WeatherApp.DataModel.Models;
using Microsoft.AspNetCore.Hosting;

namespace WeatherApp.BL.Services
{
    public class Export
    {
        private readonly DataContext _context;
        private readonly IHostingEnvironment _appEnvironment;

        public Export (DataContext context, IHostingEnvironment appEnvironment)
        {
            _context = context;
            _appEnvironment = appEnvironment;
        }

        public string Unpack(string path)
        {
            var p = $"{_appEnvironment.WebRootPath}/Files";
            ZipFile.ExtractToDirectory(_appEnvironment.WebRootPath + path, p);
            return p;
        }

        public void ExcelExport(string path)
        {
            XSSFWorkbook hssfwb;
            using (var file = new FileStream(path, FileMode.Open, FileAccess.Read))
            {
                hssfwb = new XSSFWorkbook(file);
            }
            for (var i = 0; i < hssfwb.NumberOfSheets; i++)
            {
                var sheet = hssfwb.GetSheetAt(i);

                for (int row = 0; row <= sheet.LastRowNum; row++)
                {
                    var currentRow = sheet.GetRow(row);
                    if (currentRow != null)
                    {
                        DateTime dateTime;
                        if ((row == 2 && currentRow.GetCell(0).ToString() != "Дата") ||
                            (row == 4 && !DateTime.TryParse(currentRow.GetCell(0).ToString(), out dateTime)))
                        {
                            throw new Exception("Ошибка структуры");
                        }
                        if (row >= 4)
                        {
                            var date = $"{currentRow.GetCell(0)} {currentRow.GetCell(1)}";
                            
                            var speedWind = currentRow.GetCell(7).ToString().Trim();
                            var overCastTrim = currentRow.GetCell(8).ToString().Trim();
                            var hTrim = currentRow.GetCell(9).ToString().Trim();

                            var weather = new Weather
                            {
                                TimeMeasuring = DateTime.Parse(date),
                                Temperature = currentRow.GetCell(2).NumericCellValue,
                                Humidity = currentRow.GetCell(3).NumericCellValue,
                                Td = currentRow.GetCell(4).NumericCellValue,
                                Atmosphere = (int) currentRow.GetCell(5).NumericCellValue,
                                SpeedWind = speedWind == "" ? null : (int?)Convert.ToInt32(speedWind),
                                OverCast = overCastTrim == "" ? null : (int?) Convert.ToInt32(overCastTrim),
                                H = hTrim == "" ? null : (int?) Convert.ToInt32(hTrim),
                                VW = currentRow.GetCell(10).ToString().Trim(),
                                WeatherCondition = currentRow.GetCell(11)?.ToString(),
                                WeatherDirectionWind = currentRow.GetCell(6)?.ToString()
                            };
                            _context.Weathers.Add(weather);
                        }
                    }
                }
            }
            _context.SaveChanges();
        }
    }
}
