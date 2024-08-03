using System;
using System.Collections.Generic;

namespace KursovayaBank.Models.BaDB;

public partial class VidCredit
{
    public int idVid { get; set; }

    public int Stavka { get; set; }

    public int Srok_dney_ { get; set; }

    public virtual ICollection<Credit> Credits { get; } = new List<Credit>();
}
