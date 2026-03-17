using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GymManagement.Data;
using GymManagement.Models;
using Microsoft.AspNetCore.Authorization;

namespace GymManagement.Controllers
{
    [Authorize(Roles = "Admin,Staff")]
    public class PTSchedulesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PTSchedulesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: PTSchedules
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.PTSchedules.Include(p => p.Member).Include(p => p.PersonalTrainer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: PTSchedules/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pTSchedules = await _context.PTSchedules
                .Include(p => p.Member)
                .Include(p => p.PersonalTrainer)
                .FirstOrDefaultAsync(m => m.ScheduleID == id);
            if (pTSchedules == null)
            {
                return NotFound();
            }

            return View(pTSchedules);
        }

        // GET: PTSchedules/Create
        public IActionResult Create()
        {
            ViewData["MemberID"] = new SelectList(_context.Members, "MemberID", "Email");
            ViewData["PTID"] = new SelectList(_context.PersonalTrainers, "PTID", "FullName");
            return View();
        }

        // POST: PTSchedules/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ScheduleID,PTID,MemberID,ScheduleDate,StartTime,EndTime,SessionType,Notes,Status,CreatedAt")] PTSchedules pTSchedules)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pTSchedules);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MemberID"] = new SelectList(_context.Members, "MemberID", "Email", pTSchedules.MemberID);
            ViewData["PTID"] = new SelectList(_context.PersonalTrainers, "PTID", "FullName", pTSchedules.PTID);
            return View(pTSchedules);
        }

        // GET: PTSchedules/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pTSchedules = await _context.PTSchedules.FindAsync(id);
            if (pTSchedules == null)
            {
                return NotFound();
            }
            ViewData["MemberID"] = new SelectList(_context.Members, "MemberID", "Email", pTSchedules.MemberID);
            ViewData["PTID"] = new SelectList(_context.PersonalTrainers, "PTID", "FullName", pTSchedules.PTID);
            return View(pTSchedules);
        }

        // POST: PTSchedules/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ScheduleID,PTID,MemberID,ScheduleDate,StartTime,EndTime,SessionType,Notes,Status,CreatedAt")] PTSchedules pTSchedules)
        {
            if (id != pTSchedules.ScheduleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pTSchedules);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PTSchedulesExists(pTSchedules.ScheduleID))
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
            ViewData["MemberID"] = new SelectList(_context.Members, "MemberID", "Email", pTSchedules.MemberID);
            ViewData["PTID"] = new SelectList(_context.PersonalTrainers, "PTID", "FullName", pTSchedules.PTID);
            return View(pTSchedules);
        }

        // GET: PTSchedules/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pTSchedules = await _context.PTSchedules
                .Include(p => p.Member)
                .Include(p => p.PersonalTrainer)
                .FirstOrDefaultAsync(m => m.ScheduleID == id);
            if (pTSchedules == null)
            {
                return NotFound();
            }

            return View(pTSchedules);
        }

        // POST: PTSchedules/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pTSchedules = await _context.PTSchedules.FindAsync(id);
            if (pTSchedules != null)
            {
                _context.PTSchedules.Remove(pTSchedules);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PTSchedulesExists(int id)
        {
            return _context.PTSchedules.Any(e => e.ScheduleID == id);
        }
    }
}
