using System;
using System.Collections.Generic;

namespace BolcheWebsite.SQLModels;

public partial class Order
{
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public int CartId { get; set; }

    public DateTime OrderDate { get; set; }

    public virtual Cart Cart { get; set; } = null!;

    public virtual Customer? Customer { get; set; }
}
