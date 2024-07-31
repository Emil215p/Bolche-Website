using System;
using System.Collections.Generic;

namespace BolcheWebsite.SQLModels;

public partial class CustomersWithBluePearl
{
    public string Name { get; set; } = null!;

    public int? TotalOrders { get; set; }
}
