using System;
using System.Collections.Generic;
using static System.Net.Mime.MediaTypeNames;

namespace BolcheWebsite.SQLModels;

public partial class CombinationModel
{
    public IEnumerable<BolcheWebsite.SQLModels.BolcheView>? BolcheView { get; set; }
    public IEnumerable<BolcheWebsite.SQLModels.NettoPri>? NettoPris { get; set; }
    public IEnumerable<BolcheWebsite.SQLModels.TotalPri>? TotalPris { get; set; }
    public IEnumerable<BolcheWebsite.SQLModels.HundredGramPri>? HundredGramPris { get; set; }
}