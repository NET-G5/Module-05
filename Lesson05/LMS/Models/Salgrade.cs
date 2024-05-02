using System.ComponentModel.DataAnnotations;

namespace LMS.Models;

public class Salgrade
{
    [Key]
    public int Grade { get; set; }
    public decimal LowestSalary { get; set; }
    public decimal HighestSalary { get; set; }
}
