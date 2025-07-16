using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ResourceBookingSystem.Models
{
    public class Resource
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;
        public string Location { get; set; } = null!;

        [Range(1, int.MaxValue)]
        public int Capacity { get; set; }

        public bool IsAvailable { get; set; }

        public ICollection<Booking>? Bookings { get; set; }
    }
}
