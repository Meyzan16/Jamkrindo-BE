using System;
using System.Collections.Generic;

namespace Entities.Models.DbPenampung;

public partial class TblLogActivity
{
    public int Id { get; set; }

    public int? JumlahData { get; set; }

    public string? Status { get; set; }

    public DateTime? CreatedAt { get; set; }
}
