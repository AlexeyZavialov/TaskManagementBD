using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskManagementBD.Models;
using Task = TaskManagementBD.Models.Task;

namespace TaskManagementBD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View("ListTasks", Repository.Tasks);
        }

        public IActionResult ListTasks()
        {
            return View("ListTasks", Repository.Tasks);            
        }


        [HttpPost]
        public IActionResult ListTasks(Task task)
        {            
            if (ModelState.IsValid)
            {
                return View("EditTask", Repository.TakeTasks(task.Id - 1));
            }
            return View("Privacy");
        }

        [HttpPost]
        public IActionResult EditTask(Task task)
        {
            if (ModelState.IsValid)
            {
                Repository.UpdateTask(task);
            }
            return View("Index");           
        }

        

        public IActionResult EditTask() => 
            View("EditTask", new Task());      
        

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
