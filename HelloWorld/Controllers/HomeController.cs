using HelloWorld.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Session;
using Microsoft.EntityFrameworkCore;
using HelloWorld.Data;

namespace HelloWorld.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //const string AlertMessage = "_Message";
        //const string AlertLink = "_Link";

        public IActionResult Index()
        {
            //_context.Add(alert);
            //await _context.SaveChangesAsync();

            //HttpContext.Session.SetString(AlertMessage, "text");
            //HttpContext.Session.SetString(AlertLink, "text");
            return View();
        }

        public IActionResult Configuration()
        {
            return View();
        }

        //public string Alert()
        //{
        //    string? AMessage = HttpContext.Session.GetString(AlertMessage);
        //    string? ALink = HttpContext.Session.GetString(AlertLink);
        //    string Content = $"Message: {AMessage}, Link: {ALink}";
        //    return Content;
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
