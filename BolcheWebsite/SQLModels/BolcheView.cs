﻿using System;
using System.Collections.Generic;

namespace BolcheWebsite.SQLModels;

public partial class BolcheView
{
    public string BolcheNavn { get; set; } = null!;

    public string? Farve { get; set; }

    public string? Surhed { get; set; }

    public string? Styrke { get; set; }

    public string? Smag { get; set; }

    public decimal? Pris { get; set; }

    public decimal? Vægt { get; set; }
}
