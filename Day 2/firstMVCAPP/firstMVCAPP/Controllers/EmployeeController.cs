using Microsoft.AspNetCore.Mvc;
using firstMVCAPP.Models;

namespace firstMVCAPP.Controllers
{
    public class EmployeeController : Controller
    {

        Employee empObj = new Employee(); //this is bad code, instead use DI 
        public IActionResult DisplayEmployee()
        {
            ViewBag.allEmp = empObj.GetAllEmployees();
            return View();
        }
    }
}
