using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VoiceWeb.Models;

namespace VoiceWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _appEnvironment;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment _appEnvironment)
        {
            this._appEnvironment = _appEnvironment;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VoiceRecord(IFormFile file)
        {
            using(var filestream=new FileStream(_appEnvironment.WebRootPath + "/Files/" + file.Name, FileMode.Create))
            {
                file.CopyTo(filestream);
            }
            return RedirectToAction("Index");
        }
        public IActionResult Privacy()
        {
            return View();
        }
        [HttpPost]
        public IActionResult UploadVoice(IFormFile recording, string fileName)
        {
            return Ok();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
