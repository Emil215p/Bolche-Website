using System;
using System.Collections.Generic;

namespace BolcheWebsite.SQLModels;

public partial class Test1
{
    public string BolcheNavn { get; set; } = null!;

    public int Weight { get; set; }

    public int Price { get; set; }

    public string BolcheTrait { get; set; } = null!;

    public string TraitName2 { get; set; } = null!;
}
