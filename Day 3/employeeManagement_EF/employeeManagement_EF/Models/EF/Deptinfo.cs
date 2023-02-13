using System;
using System.Collections.Generic;

namespace employeeManagement_EF.Models.EF;

public partial class Deptinfo
{
    public int DNo { get; set; }

    public string? DName { get; set; }

    public string? DLocation { get; set; }

    public string? DEmail { get; set; }

    public virtual ICollection<EmployeeDetail> EmployeeDetails { get; } = new List<EmployeeDetail>();
}
