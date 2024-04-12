using Microsoft.AspNetCore.Mvc;
using MVC_Input_Field_Example.Models;
using System.Diagnostics;

namespace MVC_Input_Field_Example.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        static InputFieldModel model = new InputFieldModel();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(model);
        }

        [HttpPost]
        public IActionResult SaveUsername()
        {
            // Setter Username fra model til det bruker skrev inn
            model.Username = Request.Form["Username"];

            // Returner oppdatert model
            return View("Index", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
