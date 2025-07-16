using System;
using System.ComponentModel.DataAnnotations;

namespace ResourceBookingSystem.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Resource is required.")]
        [Display(Name = "Resource")]
        public int ResourceId { get; set; }

        // Navigation property to related Resource
        public Resource? Resource { get; set; }

        [Required(ErrorMessage = "Start time is required.")]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "End time is required.")]
        [Display(Name = "End Time")]
        [DateGreaterThan(nameof(StartTime), ErrorMessage = "End Time must be after Start Time.")]
        public DateTime EndTime { get; set; }

        [Required(ErrorMessage = "Booked By is required.")]
        [StringLength(100, ErrorMessage = "Booked By cannot be longer than 100 characters.")]
        [Display(Name = "Booked By")]
        public string BookedBy { get; set; } = null!;

        [Required(ErrorMessage = "Purpose is required.")]
        [StringLength(250, ErrorMessage = "Purpose cannot be longer than 250 characters.")]
        public string Purpose { get; set; } = null!;
    }

    // Custom validation attribute to check EndTime > StartTime
    public class DateGreaterThanAttribute : ValidationAttribute
    {
        private readonly string _comparisonProperty;

        public DateGreaterThanAttribute(string comparisonProperty)
        {
            _comparisonProperty = comparisonProperty;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var currentValue = (DateTime?)value;

            var property = validationContext.ObjectType.GetProperty(_comparisonProperty);
            if (property == null)
                throw new ArgumentException("Property with this name not found.");

            var comparisonValue = (DateTime?)property.GetValue(validationContext.ObjectInstance);

            if (currentValue != null && comparisonValue != null && currentValue <= comparisonValue)
            {
                return new ValidationResult(ErrorMessage);
            }

            return ValidationResult.Success;
        }
    }
}
