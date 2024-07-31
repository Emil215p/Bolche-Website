using System;
using System.Collections.Generic;

namespace BolcheWebsite.SQLModels;

public partial class CustomersWithOrder
{
    public string Name { get; set; } = null!;

    public int? TotalOrders { get; set; }
}
