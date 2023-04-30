using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventManager.Data;
using EventManager.Models;

namespace EventManager.Controllers
{
    public class LoginUserDTOesController : Controller
    {
        private readonly AppDbContext _context;

        public LoginUserDTOesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: LoginUserDTOes
        public async Task<IActionResult> Index()
        {
              return _context.LoginUserDTO != null ? 
                          View(await _context.LoginUserDTO.ToListAsync()) :
                          Problem("Entity set 'AppDbContext.LoginUserDTO'  is null.");
        }

        // GET: LoginUserDTOes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.LoginUserDTO == null)
            {
                return NotFound();
            }

            var loginUserDTO = await _context.LoginUserDTO
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loginUserDTO == null)
            {
                return NotFound();
            }

            return View(loginUserDTO);
        }

        // GET: LoginUserDTOes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: LoginUserDTOes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Email,Password")] LoginUserDTO loginUserDTO)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loginUserDTO);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(loginUserDTO);
        }

        // GET: LoginUserDTOes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.LoginUserDTO == null)
            {
                return NotFound();
            }

            var loginUserDTO = await _context.LoginUserDTO.FindAsync(id);
            if (loginUserDTO == null)
            {
                return NotFound();
            }
            return View(loginUserDTO);
        }

        // POST: LoginUserDTOes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Email,Password")] LoginUserDTO loginUserDTO)
        {
            if (id != loginUserDTO.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loginUserDTO);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoginUserDTOExists(loginUserDTO.Id))
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
            return View(loginUserDTO);
        }

        // GET: LoginUserDTOes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.LoginUserDTO == null)
            {
                return NotFound();
            }

            var loginUserDTO = await _context.LoginUserDTO
                .FirstOrDefaultAsync(m => m.Id == id);
            if (loginUserDTO == null)
            {
                return NotFound();
            }

            return View(loginUserDTO);
        }

        // POST: LoginUserDTOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.LoginUserDTO == null)
            {
                return Problem("Entity set 'AppDbContext.LoginUserDTO'  is null.");
            }
            var loginUserDTO = await _context.LoginUserDTO.FindAsync(id);
            if (loginUserDTO != null)
            {
                _context.LoginUserDTO.Remove(loginUserDTO);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LoginUserDTOExists(int id)
        {
          return (_context.LoginUserDTO?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
