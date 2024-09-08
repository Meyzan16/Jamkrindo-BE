using System;
using System.Collections.Generic;

namespace Entities.Models.DbAplikasi;

public partial class TblKlaimLob
{
    public string? SubCob { get; set; }

    public string? PenyebabKlaim { get; set; }

    public DateOnly? Periode { get; set; }

    public int? IdWilker { get; set; }

    public DateOnly? TglKeputusanKlaim { get; set; }

    public int? JumlahTerjamin { get; set; }

    public string? NilaiBebanKlaim { get; set; }

    public string? DebetKredit { get; set; }
}
