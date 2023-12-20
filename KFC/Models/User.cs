using System;
using System.Collections.Generic;

namespace KFC.Models;

public partial class User
{
    public string Login { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Fname { get; set; } = null!;

    public string? Sname { get; set; }

    public string Lname { get; set; } = null!;

    public string? Photo { get; set; }

    public string? EmplContract { get; set; }

    public int IdUser { get; set; }

    public int IdPost { get; set; }

    public int IdStatus { get; set; }

    public virtual Post IdPostNavigation { get; set; } = null!;

    public virtual StatusesUser IdStatusNavigation { get; set; } = null!;

    public virtual ICollection<UserShift> UserShifts { get; set; } = new List<UserShift>();

    public virtual ICollection<UsersOrder> UsersOrders { get; set; } = new List<UsersOrder>();
}
