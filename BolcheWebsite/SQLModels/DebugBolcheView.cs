using System;
using System.Collections.Generic;

namespace BolcheWebsite.SQLModels;

public partial class DebugBolcheView
{
    public string BolcheNavn { get; set; } = null!;

    public string? BolcheType { get; set; }

    public string? TraitNames { get; set; }
}
