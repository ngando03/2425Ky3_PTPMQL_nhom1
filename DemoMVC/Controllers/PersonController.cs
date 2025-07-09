using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DemoMVC.Data;
using DemoMVC.Models;

namespace DemoMVC.Controllers
{
    public class PersonController : Controller
    {
        private readonly ApplicationDbcontext _context;

        public PersonController(ApplicationDbcontext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Persons.ToListAsync());
        }
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Persons
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
        public IActionResult Create()
        {
            var lastPerson = _context.Persons
                .OrderByDescending(p => p.PersonID)
                .FirstOrDefault();

            

            string newID = "PS001";

            if (lastPerson != null && !string.IsNullOrEmpty(lastPerson.PersonID))
            {
                string lastId = lastPerson.PersonID.Trim();

                // Kiểm tra đúng định dạng PSxxx
                if (lastId.Length >= 3 && int.TryParse(lastId.Substring(2), out int lastNumber))
                {
                    newID = $"PS{(lastNumber + 1).ToString("D3")}";
                }
            }


            var person = new Person
            {
                PersonID = newID,
                FullName = "",
                Address = ""
            };

            return View(person);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudentID,FullName,Address")] Person person)
        {
            var lastPerson = _context.Persons
               .OrderByDescending(p => p.PersonID)
               .FirstOrDefault();



            string newID = "PS001";

            if (lastPerson != null && !string.IsNullOrEmpty(lastPerson.PersonID))
            {
                string lastId = lastPerson.PersonID.Trim();

                // Kiểm tra đúng định dạng PSxxx
                if (lastId.Length >= 3 && int.TryParse(lastId.Substring(2), out int lastNumber))
                {
                    newID = $"PS{(lastNumber + 1).ToString("D3")}";
                }
            }
            person.PersonID = newID;

            _context.Add(person);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            return View(person);
        }
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Persons.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("StudentID,FullName,Address")] Person person)
        {
            if (id != person.PersonID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(person);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentExists(person.PersonID))
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
            return View(person);
        }
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.Persons
                .FirstOrDefaultAsync(m => m.PersonID == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var student = await _context.Persons.FindAsync(id);
            if (student != null)
            {
                _context.Persons.Remove(student);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentExists(string id)
        {
            return _context.Persons.Any(e => e.PersonID == id);
        }
    }
}