using System;
using System.Collections.Generic;

namespace FLM_WEB_API.Models;

public class Coursemaster
{
    public int Id { get; set; }

    public string Coursename { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Modules { get; set; } = null!;

    public int Duration { get; set; }

    public virtual ICollection<Studentmaster> Studentmasters { get; set; } = new List<Studentmaster>();

    public virtual ICollection<Testmaster> Testmasters { get; set; } = new List<Testmaster>();
}
