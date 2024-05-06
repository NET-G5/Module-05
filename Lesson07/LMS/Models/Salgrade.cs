using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models;

public class Salgrade
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Grade { get; set; }
    public decimal LowestSalary { get; set; }
    public decimal HighestSalary { get; set; }
}
