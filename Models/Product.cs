using System;
using System.Collections.Generic;

namespace API_CoffeQ.Models;

public partial class Product
{
    public int IdProduct { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public bool? IsActive { get; set; }

    public int? Stock { get; set; }

    public double? Price { get; set; }

    public string? Image { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
