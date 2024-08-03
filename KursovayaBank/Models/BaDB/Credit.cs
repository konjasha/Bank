using System;
using System.Collections.Generic;

namespace KursovayaBank.Models.BaDB;

public partial class Credit
{
    public int idCredit { get; set; }

    public int sumCredit { get; set; }

    public int SumVyplat { get; set; }

    public int idVid { get; set; }

    public int idClient { get; set; }

    public virtual Client idClientNavigation { get; set; } = null!;

    public virtual VidCredit idV { get; set; } = null!;

    public virtual ICollection<statusCredit> statusCredits { get; } = new List<statusCredit>();
}
