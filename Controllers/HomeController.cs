using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResourceBookingSystem.Data;
using ResourceBookingSystem.Models;

public class HomeController : Controller
{
    private readonly ApplicationDbContext _context;

    public HomeController(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        var upcomingBookings = await _context.Bookings
            .Include(b => b.Resource)
            .Where(b => b.StartTime > DateTime.Now)
            .OrderBy(b => b.StartTime)
            .Take(5)
            .ToListAsync();

        var totalResources = await _context.Resources.CountAsync();

        var viewModel = new HomeIndexViewModel
        {
            UpcomingBookings = upcomingBookings,
            TotalResources = totalResources
        };

        return View(viewModel);
    }
}
