using System;
using System.Collections.Generic;

namespace BolcheWebsite.SQLModels;

public partial class BolcheTyper
{
    public int BolcheTypeId { get; set; }

    public int TraitNameId { get; set; }

    public string Name { get; set; } = null!;

    public virtual BolcheTraitName TraitName { get; set; } = null!;
}
