using System;
using System.Collections.Generic;

namespace API_CoffeQ.Models;

public partial class Payment
{
    public int IdPayment { get; set; }

    public int? IdOrder { get; set; }

    public double? Amount { get; set; }

    public string? Ref { get; set; }

    public DateTime? Date { get; set; }
    public bool? IsApproved { get; set; }


    public virtual Order? IdOrderNavigation { get; set; }
}
