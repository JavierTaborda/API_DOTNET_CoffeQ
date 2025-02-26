using System;
using System.Collections.Generic;

namespace API_CoffeQ.DTOs;

public partial class PaymentDTO
{
    public int IdPayment { get; set; }

    public int? IdOrder { get; set; }

    public double? Amount { get; set; }

    public string? Ref { get; set; }

    public bool? IsApproved { get; set; }
    public DateTime? Date { get; set; }
    public string? CustomerName { get; set; }
}
