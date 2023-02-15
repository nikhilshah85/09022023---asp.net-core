using Microsoft.AspNetCore.Mvc;
using api_calls.Models;
namespace api_calls.Controllers
{
    public class ServerCallsController : Controller
    {


        CommentsData dataObj = new CommentsData();
        WorkToDo workData = new WorkToDo();
        public IActionResult Comments()
        {
            ViewBag.comments = dataObj.GetComments();

            return View();
        }

        public IActionResult WorkData()
        {
            ViewBag.work = workData.GetWorkToBeDone();
            return View();
        }
    }
}
