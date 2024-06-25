using System;
using System.Collections.Generic;

namespace BolcheWebsite.SQLModels;

public partial class Customer
{
    public int CustomerId { get; set; }

    public string Name { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Phone { get; set; } = null!;

    public string Password { get; set; } = null!;

    public int? ShippingInfoId { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();

    public virtual ShippingInfo? ShippingInfo { get; set; }
}
