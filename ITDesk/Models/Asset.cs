using System.ComponentModel.DataAnnotations;

namespace ITDesk.Models
{
    public class Asset
    {
        public int Id { get; set; }

        [Required]
        public string AssetType { get; set; } = string.Empty;

        [Required]
        public string AssetName { get; set; } = string.Empty;

        public string? AssignedTo { get; set; }
    }
}
