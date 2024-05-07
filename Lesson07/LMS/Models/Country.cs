using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics;

namespace LMS.Models;

[Table(nameof(Country))]
public class Country
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100, ErrorMessage = "City name must have max 100 characters.")]
    [MinLength(15, ErrorMessage = "City name must have at least 15 characters.")]
    public string Name { get; set; }

    public virtual ICollection<City> Cities { get; set; }
}
