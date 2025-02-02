﻿using System;
using System.Collections.Generic;

namespace API_CoffeQ.Models;

public partial class Customer
{
    public int IdCustomer { get; set; }

    public string? Name { get; set; }

    public string? Cedula { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
