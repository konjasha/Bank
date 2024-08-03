using System;
using System.Collections.Generic;

namespace KursovayaBank.Models.BaDB;

public partial class adres
{
    public int idAdres { get; set; }

    public string adresReg { get; set; } = null!;

    public string? adresFact { get; set; }

    public int? klientId { get; set; }

    public virtual Client? klient { get; set; }
}
