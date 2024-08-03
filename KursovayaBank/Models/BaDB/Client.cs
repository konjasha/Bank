using System;
using System.Collections.Generic;

namespace KursovayaBank.Models.BaDB;

public partial class Client
{
    public int idclient { get; set; }

    public string fio { get; set; } = null!;

    public long? phone { get; set; }

    public string gender { get; set; } = null!;

    public DateOnly dateofbirth { get; set; }

    public virtual ICollection<Credit> Credits { get; } = new List<Credit>();

    public virtual ICollection<adres> adres { get; } = new List<adres>();

    public virtual ICollection<creditHist> creditHists { get; } = new List<creditHist>();

    public virtual ICollection<document> documents { get; } = new List<document>();
}
