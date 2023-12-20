using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace KFC.Models;

public partial class Dish
{
    public int IdDish { get; set; }

    public string Name { get; set; } = null!;

    public double Price { get; set; }
    
    [NotMapped] public int CountDishes { get; set; } = 1;
    
    [NotMapped] public bool SelectDish { get; set; } = false;

    public virtual ICollection<OrderDish> OrderDishes { get; set; } = new List<OrderDish>();
}
