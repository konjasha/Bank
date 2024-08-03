using System;
using System.Collections.Generic;

namespace KursovayaBank.Models.BaDB;

public partial class statusCredit
{
    public int idStatus { get; set; }

    public string Zayavka { get; set; } = null!;

    public string Status { get; set; } = null!;

    public DateOnly? dataOtkr { get; set; }

    public DateOnly? dataZakr { get; set; }

    public int idCredit { get; set; }

    public virtual Credit idCreditNavigation { get; set; } = null!;
}
