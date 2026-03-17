using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GymManagement.Data;
using GymManagement.Models;

namespace GymManagement.Controllers
{
    public class CheckInLogsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CheckInLogsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CheckInLogs
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CheckInLogs.Include(c => c.Member);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CheckInLogs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkInLog = await _context.CheckInLogs
                .Include(c => c.Member)
                .FirstOrDefaultAsync(m => m.LogID == id);
            if (checkInLog == null)
            {
                return NotFound();
            }

            return View(checkInLog);
        }

        // GET: CheckInLogs/Create
        public IActionResult Create()
        {
            ViewData["MemberID"] = new SelectList(_context.Members, "MemberID", "Email");
            return View();
        }

        // POST: CheckInLogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LogID,MemberID,CheckInTime,CheckOutTime,CardNo,CreatedAt")] CheckInLog checkInLog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checkInLog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MemberID"] = new SelectList(_context.Members, "MemberID", "Email", checkInLog.MemberID);
            return View(checkInLog);
        }

        // GET: CheckInLogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkInLog = await _context.CheckInLogs.FindAsync(id);
            if (checkInLog == null)
            {
                return NotFound();
            }
            ViewData["MemberID"] = new SelectList(_context.Members, "MemberID", "Email", checkInLog.MemberID);
            return View(checkInLog);
        }

        // POST: CheckInLogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LogID,MemberID,CheckInTime,CheckOutTime,CardNo,CreatedAt")] CheckInLog checkInLog)
        {
            if (id != checkInLog.LogID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checkInLog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckInLogExists(checkInLog.LogID))
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
            ViewData["MemberID"] = new SelectList(_context.Members, "MemberID", "Email", checkInLog.MemberID);
            return View(checkInLog);
        }

        // GET: CheckInLogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkInLog = await _context.CheckInLogs
                .Include(c => c.Member)
                .FirstOrDefaultAsync(m => m.LogID == id);
            if (checkInLog == null)
            {
                return NotFound();
            }

            return View(checkInLog);
        }

        // POST: CheckInLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var checkInLog = await _context.CheckInLogs.FindAsync(id);
            if (checkInLog != null)
            {
                _context.CheckInLogs.Remove(checkInLog);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckInLogExists(int id)
        {
            return _context.CheckInLogs.Any(e => e.LogID == id);
        }
    }
}
