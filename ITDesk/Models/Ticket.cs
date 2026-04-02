using System.ComponentModel.DataAnnotations;

namespace ITDesk.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        public string Category { get; set; } = string.Empty;

        [Required]
        public string Priority { get; set; } = string.Empty;

        [Required]
        public string Description { get; set; } = string.Empty;

        public string Status { get; set; } = "Open";

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string EmployeeId { get; set; } = string.Empty;

        public string? AssignedToId { get; set; }

        public string? AttachmentPath { get; set; }
    }
}
