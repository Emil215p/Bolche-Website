using System;
using System.Collections.Generic;

namespace BolcheWebsite.SQLModels;

public partial class Bolcher
{
    public int BolcheId { get; set; }

    public string Name { get; set; } = null!;

    public int Weight { get; set; }

    public int Price { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();
}
