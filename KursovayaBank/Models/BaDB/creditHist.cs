using System;
using System.Collections.Generic;

namespace KursovayaBank.Models.BaDB;

public partial class creditHist
{
    public int idCredithist { get; set; }

    public string Bank { get; set; } = null!;

    public string StatusHist { get; set; } = null!;

    public DateOnly? dateOtkryt { get; set; }

    public int? Summa { get; set; }

    public int? idClient { get; set; }

    public virtual Client? idClientNavigation { get; set; }
}
