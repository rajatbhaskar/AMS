using AMS.Data;
using AMS.Models;
using AMS.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AMS.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _dbContext;  

        public HomeController(ILogger<HomeController> logger , ApplicationDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext; 

        }

        public IActionResult Dashboard()
        {
            return View();
        }


        public IActionResult AddAttendance()
        {

            ViewBag.subjects = new SelectList(_dbContext.Subject_Infos, "SubjectId", "SubjectName");
            return View();
        }

        [HttpPost]
        public IActionResult AddAttendance(AddAttendenceVM modeldata)
        {

            
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
