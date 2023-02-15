using Microsoft.AspNetCore.Mvc;

namespace api_calls.Controllers
{
    public class ApicallsController : Controller
    {
       
        public IActionResult CommentsData()
        {
            return View();
        }

        public IActionResult showUsers()
        {
            return View();
        }


    }
}
