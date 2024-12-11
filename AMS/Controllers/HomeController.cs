using AMS.Data;
using AMS.Models;
using AMS.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;

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
            var studentlist= _dbContext.Student_Masters.ToList();
            var subjectlist = _dbContext.Subject_Infos.ToList();
            var result = (from st in studentlist // outer sequence
                         join sb in subjectlist //inner sequence 
                         on st.SubjectId equals sb.SubjectId // key selector 
                         select new
                         { 
                             
                             SubjectName = sb.SubjectName,
                             IsPresent=  st.IsPresent,
                             IsAbsent= st.IsPresent,
                        });
            AddAttendenceVM obj = new AddAttendenceVM();
            //obj.StudentList = result.ToList();
            return View(result);
        }

        [HttpPost]
        public IActionResult AddAttendance(AddAttendenceVM modeldata)
        {  if (ModelState.IsValid)
            {
                Student_Master stdmaster = new Student_Master();
                {
                    stdmaster.Date = modeldata.Date;
                    stdmaster.SubjectId= modeldata.SubjectId; 
                    if(modeldata.IsPresent==false)
                        stdmaster.IsAbsent = true;
                    stdmaster.IsPresent= modeldata.IsPresent;
                };

                var result=_dbContext.Add(stdmaster);
                _dbContext.SaveChanges();
                TempData["AlertMsg"] = "Attendence Added Successfully";
                RedirectToAction("AddAttendance");


            }

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
