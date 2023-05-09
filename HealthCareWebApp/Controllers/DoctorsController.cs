using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HealthCareWebApp;
using HealthCareWebApp.Models;
using Microsoft.CodeAnalysis;

namespace HealthCareWebApp.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly HealthCareWebAppContext _context;

        public DoctorsController(HealthCareWebAppContext context)
        {
            _context = context;
        }

        // GET: Doctors
        public async Task<IActionResult> Index(string? name, string? specialty, string? location)
        {
            if (specialty == null && name==null && location==null)
            {            
            return _context.Doctor != null ? 
                          View(await _context.Doctor.ToListAsync()) :
                          Problem("Entity set 'HealthCareWebAppContext.Doctor'  is null.");
            }

            var doctors = _context.Doctor.AsQueryable();

            if (!string.IsNullOrEmpty(name))
            {
                doctors = doctors.Where(d => d.Name.Contains(name));
            }

            if (!string.IsNullOrEmpty(specialty))
            {
                doctors = doctors.Where(d => d.Specialty.Contains(specialty));
            }

            if (!string.IsNullOrEmpty(location))
            {
                doctors = doctors.Where(d => d.Location.Contains(location));
            }

            var results = await doctors.ToListAsync();

            return View(results);
        }

        // GET: Doctors/Details/5


        //ACCEPT ONLY INTEGER
        [Route("Doctors/Details/{id:int}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Doctor == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // GET: Doctors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Specialty,ContactInfo,Location")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }

        // GET: Doctors/Edit/5
      
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Doctor == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor.FindAsync(id);
            if (doctor == null)
            {
                return NotFound();
            }
            return View(doctor);
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Specialty,ContactInfo")] Doctor doctor)
        {
            if (id != doctor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExists(doctor.Id))
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
            return View(doctor);
        }

        // GET: Doctors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Doctor == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctor
                .FirstOrDefaultAsync(m => m.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Doctor == null)
            {
                return Problem("Entity set 'HealthCareWebAppContext.Doctor'  is null.");
            }
            var doctor = await _context.Doctor.FindAsync(id);
            if (doctor != null)
            {
                _context.Doctor.Remove(doctor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


        private bool DoctorExists(int id)
        {
          return (_context.Doctor?.Any(e => e.Id == id)).GetValueOrDefault();
        }



       
       



    }
}
