using System;
using System.Collections.Generic;

namespace API_CoffeQ.DTOs;

public partial class OrderDTO
{
    public int IdOrder { get; set; }

    public int IdCustomer { get; set; }

    public DateTime? Date { get; set; }

    public double? Total { get; set; }

    public string? CustomerName { get; set; }

    public virtual ICollection<OrderDetailDTO> OrderDetailsDTO { get; set; } =[];

 
}
