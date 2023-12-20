using System;
using System.Collections.Generic;

namespace KFC.Models;

public partial class StatusesUser
{
    public int IdStatus { get; set; }

    public string Name { get; set; } = null!;

    public virtual ICollection<User> Users { get; set; } = new List<User>();
}
