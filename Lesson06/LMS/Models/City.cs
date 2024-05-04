using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models;

[Table(nameof(City))]
public class City
{
    public int Id { get; set; }

    [Required]
    [MaxLength(100, ErrorMessage = "City name must have max 100 characters.")]
    [MinLength(15, ErrorMessage = "City name must have at least 15 characters.")]
    public string Name { get; set; }

    [DataType(DataType.Text)]
    public string? Description { get; set; }

    [ForeignKey(nameof(CountryId))]
    public Country Country { get; set; }
    public int CountryId { get; set; }

    public virtual ICollection<Street> Streets { get; set; }
}
