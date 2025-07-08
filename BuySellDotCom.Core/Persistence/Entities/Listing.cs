using System.ComponentModel.DataAnnotations;
using BuySellDotCom.Core.Enums;

namespace BuySellDotCom.Core.Persistence.Entities;

public class Listing
{
    public int Id { get; set; }

    [Required]
    [MinLength(3)]
    [MaxLength(100)]
    public required string Name { get; set; }

    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Price must be non-negative")]
    public required decimal Price { get; set; }

    [Required]
    public required Condition Condition { get; set; }

    [Url]
    public string? ImageUrl { get; set; }

    [Required]
    public required Category Category { get; set; }

    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    public ICollection<Tag> Tags { get; set; } = new List<Tag>();

    [Required]
    public required User User { get; set; }

    [Required]
    public required int UserId { get; set; }
}

