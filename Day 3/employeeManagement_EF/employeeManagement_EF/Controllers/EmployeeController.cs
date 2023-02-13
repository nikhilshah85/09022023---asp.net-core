using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using employeeManagement_EF.Models.EF;

namespace employeeManagement_EF.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeDbContext _context = new EmployeeDbContext();

        //public EmployeeController(EmployeeDbContext context)
        //{
        //    _context = context;
        //}

        // GET: Employee
        public async Task<IActionResult> Index()
        {
            var employeeDbContext = _context.EmployeeDetails.Include(e => e.DeptNavigation);
            return View(await employeeDbContext.ToListAsync());
        }

        // GET: Employee/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EmployeeDetails == null)
            {
                return NotFound();
            }

            var employeeDetail = await _context.EmployeeDetails
                .Include(e => e.DeptNavigation)
                .FirstOrDefaultAsync(m => m.EmpNo == id);
            if (employeeDetail == null)
            {
                return NotFound();
            }

            return View(employeeDetail);
        }

        // GET: Employee/Create
        public IActionResult Create()
        {
            ViewData["Dept"] = new SelectList(_context.Deptinfos, "DNo", "DNo");
            return View();
        }

        // POST: Employee/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpNo,EmpName,EmpDesigantion,EmpSalary,EmpIsPermenant,Dept")] EmployeeDetail employeeDetail)
        {
            if (ModelState.IsValid)
            {
                _context.Add(employeeDetail);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Dept"] = new SelectList(_context.Deptinfos, "DNo", "DNo", employeeDetail.Dept);
            return View(employeeDetail);
        }

        // GET: Employee/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EmployeeDetails == null)
            {
                return NotFound();
            }

            var employeeDetail = await _context.EmployeeDetails.FindAsync(id);
            if (employeeDetail == null)
            {
                return NotFound();
            }
            ViewData["Dept"] = new SelectList(_context.Deptinfos, "DNo", "DNo", employeeDetail.Dept);
            return View(employeeDetail);
        }

        // POST: Employee/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpNo,EmpName,EmpDesigantion,EmpSalary,EmpIsPermenant,Dept")] EmployeeDetail employeeDetail)
        {
            if (id != employeeDetail.EmpNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employeeDetail);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmployeeDetailExists(employeeDetail.EmpNo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Dept"] = new SelectList(_context.Deptinfos, "DNo", "DNo", employeeDetail.Dept);
            return View(employeeDetail);
        }

        // GET: Employee/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EmployeeDetails == null)
            {
                return NotFound();
            }

            var employeeDetail = await _context.EmployeeDetails
                .Include(e => e.DeptNavigation)
                .FirstOrDefaultAsync(m => m.EmpNo == id);
            if (employeeDetail == null)
            {
                return NotFound();
            }

            return View(employeeDetail);
        }

        // POST: Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EmployeeDetails == null)
            {
                return Problem("Entity set 'EmployeeDbContext.EmployeeDetails'  is null.");
            }
            var employeeDetail = await _context.EmployeeDetails.FindAsync(id);
            if (employeeDetail != null)
            {
                _context.EmployeeDetails.Remove(employeeDetail);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmployeeDetailExists(int id)
        {
          return (_context.EmployeeDetails?.Any(e => e.EmpNo == id)).GetValueOrDefault();
        }
    }
}
