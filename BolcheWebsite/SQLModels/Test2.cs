using System;
using System.Collections.Generic;

namespace BolcheWebsite.SQLModels;

public partial class Test2
{
    public string BolcheNavn { get; set; } = null!;

    public string? BolcheTrait { get; set; }

    public int Weight { get; set; }

    public int Price { get; set; }
}
