using System;
using System.Collections.Generic;

namespace API_CoffeQ.DTOs;

public partial class ProductDTO
{
    public int IdProduct { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? IsActive { get; set; }

    public string? Stock { get; set; }

    public double? Price { get; set; }

    public string? Image { get; set; }

}
