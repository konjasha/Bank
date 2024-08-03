using System;
using System.Collections.Generic;

namespace KursovayaBank.Models.BaDB;

public partial class document
{
    public int idDocument { get; set; }

    public string vidDocument { get; set; } = null!;

    public int nomerDocument { get; set; }

    public DateOnly? dataVydachi { get; set; }

    public int? idClient { get; set; }

    public virtual Client? idClientNavigation { get; set; }
}
