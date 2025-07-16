using System.Collections.Generic;

namespace ResourceBookingSystem.Models
{
    public class HomeIndexViewModel
    {
        public List<Booking> UpcomingBookings { get; set; } = new();
        public int TotalResources { get; set; }
    }
}
