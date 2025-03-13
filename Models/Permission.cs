using System;
using System.Collections.Generic;

namespace API_CoffeQ.Models;

public partial class Permission
{
    public int IdPermission { get; set; }

    public int? IdCustomer { get; set; }

    public bool? IsActive { get; set; }
}
