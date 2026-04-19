using System;
using System.Collections.Generic;

namespace FLM_WEB_API.Models;

public partial class Studentattemptdetail
{
    public int Id { get; set; }

    public int? Fkstudid { get; set; }

    public int? Fktestquestionid { get; set; }

    public int? Selectedans { get; set; }

    public bool? Iscorrect { get; set; }

    public virtual Studentmaster? Fkstud { get; set; }

    public virtual Testquestion? Fktestquestion { get; set; }
}
