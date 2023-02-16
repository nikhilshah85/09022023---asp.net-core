using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using api_DevelopmentDemo.Models;
namespace api_DevelopmentDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        Employee empObj = new Employee();
        [HttpGet]
        [Route("greet")]
        public IActionResult Greetings()
        {
            return Ok("Hello and Welcome to API");
        }

        [HttpGet]
        [Route("friendlist")]
        public IActionResult Friends()
        {
            List<string> friends = new List<string>() { "Sameer", "Mohan", "Manoj", "Akshay", "Rohit", "Sam", "Khush" };
            return Ok(friends);
        }


        [HttpGet]
        [Route("employees")]
        public IActionResult GetAllEmployees()
        {
            var allemp = empObj.GetAllEmployee();
            return Ok(allemp);
        }

        [HttpGet]
        [Route("employee/eid")]
        public IActionResult GetEmpById(int eid)
        {
            try
            {
                var emp = empObj.GetEmployeeByNo(eid);
                return Ok(emp);
            }
            catch(Exception es)
            {
                return NotFound(es.Message);
            }
        }

        [HttpGet]
        [Route("ispermenant")]
        public IActionResult GetEmpByStatus(bool ispermenant)
        {
            try
            {
                var allemp = empObj.GetEmployeesByStatus(ispermenant);
                return Ok(allemp);
            }
            catch (Exception es)
            {
                return NotFound(es.Message);
                
            }
        }

        [HttpGet]
        [Route("totalcount")]
        public IActionResult GetTotalEmployees()
        {
            return Ok(empObj.TotalEmployees());
        }

        [HttpGet]
        [Route("totalsalary")]
        public IActionResult GetTotalSalaryPaid()
        {
            return Ok(empObj.TotalSalaryPaid());
        }
        
    }
}











