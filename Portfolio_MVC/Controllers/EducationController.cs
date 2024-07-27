using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portfolio_MVC.Data;
using Portfolio_MVC.Models;

namespace Portfolio_MVC.Controllers
{
    public class EducationController : Controller
    {
        private readonly Portfolio_MVCContext _context;

        public EducationController(Portfolio_MVCContext context)
        {
            _context = context;
        }

        // GET: Education
        public async Task<IActionResult> Index()
        {
            return View(await _context.PortfolioDetails.ToListAsync());
        }

        // GET: Education/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolioDetails = await _context.PortfolioDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (portfolioDetails == null)
            {
                return NotFound();
            }

            return View(portfolioDetails);
        }

        // GET: Education/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Education/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClassName,ClassGrade,Description")] PortfolioDetails portfolioDetails)
        {
            if (ModelState.IsValid)
            {
                _context.Add(portfolioDetails);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(portfolioDetails);
        }

        // GET: Education/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolioDetails = await _context.PortfolioDetails.FindAsync(id);
            if (portfolioDetails == null)
            {
                return NotFound();
            }
            return View(portfolioDetails);
        }

        // POST: Education/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClassName,ClassGrade,Description")] PortfolioDetails portfolioDetails)
        {
            if (id != portfolioDetails.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(portfolioDetails);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PortfolioDetailsExists(portfolioDetails.Id))
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
            return View(portfolioDetails);
        }

        // GET: Education/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var portfolioDetails = await _context.PortfolioDetails
                .FirstOrDefaultAsync(m => m.Id == id);
            if (portfolioDetails == null)
            {
                return NotFound();
            }

            return View(portfolioDetails);
        }

        // POST: Education/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var portfolioDetails = await _context.PortfolioDetails.FindAsync(id);
            if (portfolioDetails != null)
            {
                _context.PortfolioDetails.Remove(portfolioDetails);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PortfolioDetailsExists(int id)
        {
            return _context.PortfolioDetails.Any(e => e.Id == id);
        }
    }
}
