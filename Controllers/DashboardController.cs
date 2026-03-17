using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GymManagement.Data;

namespace GymManagement.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DashboardController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var model = new DashboardViewModel
            {
                TotalMembers = await _context.Members.CountAsync(),
                ActiveMembers = await _context.Members.CountAsync(m => m.Status == "Active"),
                TotalPTs = await _context.PersonalTrainers.CountAsync(),
                AvailablePTs = await _context.PersonalTrainers.CountAsync(pt => pt.IsAvailable),
                TodaySchedules = await _context.PTSchedules.CountAsync(s => s.ScheduleDate == DateTime.Now.Date),
                TodayCheckIns = await _context.CheckInLogs.CountAsync(c => c.CheckInTime.Date == DateTime.Now.Date),
                CurrentCheckedIn = await _context.CheckInLogs.CountAsync(c => c.CheckOutTime == null),
                ExpiringSoon = await _context.Members.CountAsync(m =>
                    m.EndDate.HasValue &&
                    m.EndDate.Value > DateTime.Now &&
                    m.EndDate.Value <= DateTime.Now.AddDays(7))
            };

            return View(model);
        }
    }

    public class DashboardViewModel
    {
        public int TotalMembers { get; set; }
        public int ActiveMembers { get; set; }
        public int TotalPTs { get; set; }
        public int AvailablePTs { get; set; }
        public int TodaySchedules { get; set; }
        public int TodayCheckIns { get; set; }
        public int CurrentCheckedIn { get; set; }
        public int ExpiringSoon { get; set; }
    }
}