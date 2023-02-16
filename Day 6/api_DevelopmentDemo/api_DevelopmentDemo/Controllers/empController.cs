﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using api_DevelopmentDemo.Models.EF;

namespace api_DevelopmentDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class empController : ControllerBase
    {
        private readonly EmployeeDbContext _context = new EmployeeDbContext();

        //public empController(EmployeeDbContext context)
        //{
        //    _context = context;
        //}

        // GET: api/emp
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDetail>>> GetEmployeeDetails()
        {
          if (_context.EmployeeDetails == null)
          {
              return NotFound();
          }
            return await _context.EmployeeDetails.ToListAsync();
        }

        // GET: api/emp/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDetail>> GetEmployeeDetail(int id)
        {
          if (_context.EmployeeDetails == null)
          {
              return NotFound();
          }
            var employeeDetail = await _context.EmployeeDetails.FindAsync(id);

            if (employeeDetail == null)
            {
                return NotFound();
            }

            return employeeDetail;
        }

        // PUT: api/emp/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeDetail(int id, EmployeeDetail employeeDetail)
        {
            if (id != employeeDetail.EmpNo)
            {
                return BadRequest();
            }

            _context.Entry(employeeDetail).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeDetailExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/emp
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeDetail>> PostEmployeeDetail(EmployeeDetail employeeDetail)
        {
          if (_context.EmployeeDetails == null)
          {
              return Problem("Entity set 'EmployeeDbContext.EmployeeDetails'  is null.");
          }
            _context.EmployeeDetails.Add(employeeDetail);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeeDetailExists(employeeDetail.EmpNo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetEmployeeDetail", new { id = employeeDetail.EmpNo }, employeeDetail);
        }

        // DELETE: api/emp/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeDetail(int id)
        {
            if (_context.EmployeeDetails == null)
            {
                return NotFound();
            }
            var employeeDetail = await _context.EmployeeDetails.FindAsync(id);
            if (employeeDetail == null)
            {
                return NotFound();
            }

            _context.EmployeeDetails.Remove(employeeDetail);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeDetailExists(int id)
        {
            return (_context.EmployeeDetails?.Any(e => e.EmpNo == id)).GetValueOrDefault();
        }
    }
}
