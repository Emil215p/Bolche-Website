using System;
using System.Collections.Generic;

namespace BolcheWebsite.SQLModels;

public partial class OrderItem
{
    public int OrderItemId { get; set; }

    public int OrderId { get; set; }

    public int CartId { get; set; }

    public virtual Cart Cart { get; set; } = null!;

    public virtual Order Order { get; set; } = null!;
}
