using System;
using System.Collections.Generic;

namespace AspCoreWebAPICurd.Models;

public partial class Student
{
    public int StdId { get; set; }

    public string? StdName { get; set; }

    public string? StdFather { get; set; }

    public int? StdAge { get; set; }

    public string? StdGender { get; set; }

    public DateTime? StdDoj { get; set; }

    public int? StdClass { get; set; }
}
