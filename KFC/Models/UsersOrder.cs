using System;
using System.Collections.Generic;

namespace KFC.Models;

public partial class UsersOrder
{
    public int IdList { get; set; }

    public int IdUser { get; set; }

    public int IdOrder { get; set; }

    public virtual Order IdOrderNavigation { get; set; } = null!;

    public virtual User IdUserNavigation { get; set; } = null!;
}
