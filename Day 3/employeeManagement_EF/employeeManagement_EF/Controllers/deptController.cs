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
    public class deptController : Controller
    {
        private readonly EmployeeDbContext _context = new EmployeeDbContext();

        //public deptController(EmployeeDbContext context)
        //{
        //    _context = context;
        //}

        // GET: dept
        public async Task<IActionResult> Index()
        {
              return _context.Deptinfos != null ? 
                          View(await _context.Deptinfos.ToListAsync()) :
                          Problem("Entity set 'EmployeeDbContext.Deptinfos'  is null.");
        }

        // GET: dept/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Deptinfos == null)
            {
                return NotFound();
            }

            var deptinfo = await _context.Deptinfos
                .FirstOrDefaultAsync(m => m.DNo == id);
            if (deptinfo == null)
            {
                return NotFound();
            }

            return View(deptinfo);
        }

        // GET: dept/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: dept/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DNo,DName,DLocation,DEmail")] Deptinfo deptinfo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(deptinfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(deptinfo);
        }

        // GET: dept/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Deptinfos == null)
            {
                return NotFound();
            }

            var deptinfo = await _context.Deptinfos.FindAsync(id);
            if (deptinfo == null)
            {
                return NotFound();
            }
            return View(deptinfo);
        }

        // POST: dept/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DNo,DName,DLocation,DEmail")] Deptinfo deptinfo)
        {
            if (id != deptinfo.DNo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(deptinfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeptinfoExists(deptinfo.DNo))
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
            return View(deptinfo);
        }

        // GET: dept/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Deptinfos == null)
            {
                return NotFound();
            }

            var deptinfo = await _context.Deptinfos
                .FirstOrDefaultAsync(m => m.DNo == id);
            if (deptinfo == null)
            {
                return NotFound();
            }

            return View(deptinfo);
        }

        // POST: dept/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Deptinfos == null)
            {
                return Problem("Entity set 'EmployeeDbContext.Deptinfos'  is null.");
            }
            var deptinfo = await _context.Deptinfos.FindAsync(id);
            if (deptinfo != null)
            {
                _context.Deptinfos.Remove(deptinfo);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DeptinfoExists(int id)
        {
          return (_context.Deptinfos?.Any(e => e.DNo == id)).GetValueOrDefault();
        }
    }
}
