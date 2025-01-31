using System;
using System.Collections.Generic;

namespace API_CoffeQ.DTOs;

public partial class OrderDetailDTO
{
    public int IdOrderDetail { get; set; }

    public int? IdOrder { get; set; }

    public int? IdProduct { get; set; }

    public int? Quantity { get; set; }

    public double? Subtotal { get; set; }

    public bool? IsPaid { get; set; }

    public string? ProductName { get; set; }

    public DateTime? Date { get; set; }

    public DateTime? DatePaid { get; set; }


    //public virtual OrderDTO? IdOrderNavigationDTO { get; set; }

}
