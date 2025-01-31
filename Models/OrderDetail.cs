using System;
using System.Collections.Generic;

namespace API_CoffeQ.Models;

public partial class OrderDetail
{
    public int IdOrderDetail { get; set; }

    public int? IdOrder { get; set; }

    public int? IdProduct { get; set; }

    public int? Quantity { get; set; }

    public double? Subtotal { get; set; }

    public bool? IsPaid { get; set; }

    public DateTime? Date { get; set; }

    public DateTime? DatePaid { get; set; }

    public virtual Order? IdOrderNavigation { get; set; }

    public virtual Product? IdProductNavigation { get; set; }
}
