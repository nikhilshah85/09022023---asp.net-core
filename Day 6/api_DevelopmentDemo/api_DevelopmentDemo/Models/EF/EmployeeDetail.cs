using System;
using System.Collections.Generic;

namespace api_DevelopmentDemo.Models.EF;

public partial class EmployeeDetail
{
    public int EmpNo { get; set; }

    public string? EmpName { get; set; }

    public string? EmpDesigantion { get; set; }

    public int? EmpSalary { get; set; }

    public bool? EmpIsPermenant { get; set; }

    public int? Dept { get; set; }

    public virtual Deptinfo? DeptNavigation { get; set; }
}
