using System;
using System.Collections.Generic;

namespace KFC.Models;

public partial class WorkShift
{
    public int IdShift { get; set; }

    public DateTime Start { get; set; }

    public DateTime End { get; set; }

    public virtual ICollection<UserShift> UserShifts { get; set; } = new List<UserShift>();
}
