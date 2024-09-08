using System;
using System.Collections.Generic;

namespace Entities.Models.DbPenampung;

public partial class TblKlaimLobKurPen
{
    public int Id { get; set; }

    public string? SubCob { get; set; }

    public string? PenyebabKlaim { get; set; }

    public DateTime? Periode { get; set; }

    public string? NamaWilker { get; set; }

    public DateTime? TglKeputusanKlaim { get; set; }

    public int? JumlahTerjamin { get; set; }

    public string? NilaiBebanKlaim { get; set; }

    public string? DebetKredit { get; set; }
}
