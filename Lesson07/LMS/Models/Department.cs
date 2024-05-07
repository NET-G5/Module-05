using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.Models;

public class Department
{
    [Key]
    public decimal Number { get; set; }
    public string Name { get; set; }
    public string Location { get; set; }

    [ForeignKey(nameof(CityNumber))]
    public virtual City City { get; set; }
    public int CityNumber { get; set; }

    public Department()
    {
        Name = string.Empty;
        Location = string.Empty;
    }

    public Department(decimal deptno, string dname, string loc)
    {
        Number = deptno;
        Name = dname;
        Location = loc;
    }

    public override string ToString()
    {
        return $"{Name} ({Location})";
    }
}
