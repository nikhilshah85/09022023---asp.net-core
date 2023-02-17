using Microsoft.AspNetCore.Mvc;
using DI_demo.Models;
namespace DI_demo.Controllers
{
    public class EmployeeController : Controller
    {

        //This is a very bad practice
        // Employee empObj = new Employee(); 
        // we do not have any code to destroy this object


        Employee _empObj;

        public EmployeeController(Employee empObjREF) //reference to the object created by runtime
        {
            _empObj = empObjREF;
        }



        public IActionResult ShowAllEmployees()
        {
            ViewBag.allEmp = _empObj.GetAllEmployees();
            return View();
        }

        public IActionResult SearchEmployee()
        {
            ViewBag.message = "";
            return View();
        }

        [HttpPost]
        public IActionResult SearchEmployee(int empNo)
        {
            try
            {
                ViewBag.message = "";
                ViewBag.emp = _empObj.GetEmpById(empNo);
                return View();
            }
            catch (Exception es)
            {
                ViewBag.message = es.Message;
                return View();
            }
           
        }



    }
}













