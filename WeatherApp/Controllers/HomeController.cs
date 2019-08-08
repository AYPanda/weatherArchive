using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using WeatherApp.BL.Repository;

namespace WeatherApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWeatherRepository _weatherRepository;
        private readonly IHostingEnvironment _appEnvironment;
        public HomeController(IWeatherRepository weatherRepository, IHostingEnvironment appEnvironment)
        {
            _weatherRepository = weatherRepository;
            _appEnvironment = appEnvironment;
        }
        public IActionResult Index()
        {
            ViewBag.Message = TempData["Message"];
            return View();
        }

        public async Task<IActionResult> Upload(IFormFile uploadedFile)
        {
            string directoria = $"{_appEnvironment.WebRootPath}/Files";
            Directory.Delete(directoria, true); 
            Directory.CreateDirectory(directoria);
            if (uploadedFile != null)
            {
                string path = "/Files/" + uploadedFile.FileName;

                using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                {
                    await uploadedFile.CopyToAsync(fileStream);
                }

                var dirName = uploadedFile.FileName.Replace(".zip", "");
                try
                {
                    _weatherRepository.AddWeather(path, dirName);
                }
                catch (Exception e)
                {
                    TempData["Message"] = e.Message;
                    return RedirectToAction("Index");
                }
                
            }
            
            return Redirect("/");
        }
    }
}
