using System;
using System.ComponentModel.DataAnnotations;

namespace EventEase.Shared
{
    public class EventModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Event name is required")]
        [StringLength(100, ErrorMessage = "Event name must be less than 100 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Location is required")]
        [StringLength(200, ErrorMessage = "Location must be less than 200 characters")]
        public string Location { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date is required")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; } = DateTime.Today;
    }
}
