using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models;

public class Street
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }

    public City City { get; set; }
    public int CityId { get; set; }
}
