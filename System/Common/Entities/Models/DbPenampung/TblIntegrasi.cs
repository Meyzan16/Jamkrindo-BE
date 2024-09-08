using System;
using System.Collections.Generic;

namespace Entities.Models.DbPenampung;

public partial class TblIntegrasi
{
    public int Id { get; set; }

    public string? NameLob { get; set; }

    public string? PenyebabKlaim { get; set; }

    public DateTime? Periode { get; set; }

    public decimal? NilaiBebanKlaim { get; set; }

    public DateTime? CreatedAt { get; set; }
}
