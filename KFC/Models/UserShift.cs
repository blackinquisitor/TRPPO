using System;
using System.Collections.Generic;

namespace KFC.Models;

public partial class UserShift
{
    public int IdList { get; set; }

    public int IdUser { get; set; }

    public int IdShift { get; set; }

    public string Place { get; set; } = null!;

    public virtual WorkShift IdShiftNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
