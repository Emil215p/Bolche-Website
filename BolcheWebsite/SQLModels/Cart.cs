using System;
using System.Collections.Generic;

namespace BolcheWebsite.SQLModels;

public partial class Cart
{
    public int CartId { get; set; }

    public int BolcheId { get; set; }

    public int Amount { get; set; }

    public virtual Bolcher Bolche { get; set; } = null!;

    public virtual ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
}
