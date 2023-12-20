using System;
using System.Collections.Generic;

namespace KFC.Models;

public partial class Order
{
    public int IdOrder { get; set; }

    public string Place { get; set; } = null!;

    public double Price { get; set; }

    public DateTime DateAndTime { get; set; }

    public string Status { get; set; } = null!;

    public string? TypePayment { get; set; }

    public int CountClient { get; set; }

    public virtual ICollection<OrderDish> OrderDishes { get; set; } = new List<OrderDish>();

    public virtual ICollection<UsersOrder> UsersOrders { get; set; } = new List<UsersOrder>();
}
