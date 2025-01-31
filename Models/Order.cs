using System;
using System.Collections.Generic;

namespace API_CoffeQ.Models;

public partial class Order
{
    public int IdOrder { get; set; }

    public int IdCustomer { get; set; }

    public DateTime? Date { get; set; }

    public double? Total { get; set; }

    public virtual Customer IdCustomerNavigation { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<Payment> Payments { get; set; } = new List<Payment>();
}
