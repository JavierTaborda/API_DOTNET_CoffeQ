using System;
using System.Collections.Generic;

namespace API_CoffeQ.DTOs;

public partial class CustomerDTO
{
    public int IdCustomer { get; set; }

    public string? Name { get; set; }

    public string? Cedula { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

}
