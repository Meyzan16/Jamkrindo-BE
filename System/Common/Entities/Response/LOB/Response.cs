using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.Response.LOB
{
    public class ResponseData
    {
        [JsonPropertyName("data")]
        public List<ResponseViewKlaimPerLOB>? ResponseViewKlaimPerLOB { get; set; }

        [JsonPropertyName("count")]
        public List<ResponseCountKlaimPerLOB>? ResponseCountKlaimPerLOB { get; set; }
    }

    public class ResponseViewKlaimPerLOB
    {
        [JsonPropertyName("NameLob")]
        public string? name_lob { get; set; }

        [JsonPropertyName("PenyebabKlaim")]
        public string? penyebab_klaim { get; set; }

        [JsonPropertyName("JumlahTerjamin")]
        public int? jumlah_terjamin { get; set; }

        [JsonPropertyName("NilaiBebanKlaim")]
        public decimal? nilai_beban_klaim { get; set; }
    }

    public class ResponseCountKlaimPerLOB
    {
        [JsonPropertyName("NameLob")]
        public string? name_lob { get; set; }

        [JsonPropertyName("JumlahTerjamin")]
        public int? jumlah_terjamin { get; set; }

        [JsonPropertyName("NilaiBebanKlaim")]
        public decimal? nilai_beban_klaim { get; set; }
    }

    public class ResponseRekapLOB
    {
        [JsonPropertyName("NameLob")]
        public string? name_lob { get; set; }

        [JsonPropertyName("PenyebabKlaim")]
        public string? penyebab_klaim { get; set; }

        [JsonPropertyName("JumlahTerjamin")]
        public DateTime? periode { get; set; }

        [JsonPropertyName("NilaiBebanKlaim")]
        public decimal? nilai_beban_klaim { get; set; }
    }


    public class ResponseDataKlaimKurPen
    {
        [JsonPropertyName("NameLob")]
        public string? name_lob { get; set; }

        [JsonPropertyName("PenyebabKlaim")]
        public string? penyebab_klaim { get; set; }

        [JsonPropertyName("Periode")]
        public DateTime? periode { get; set; }

        [JsonPropertyName("NamaWilker")]
        public string? nama_wilker { get; set; }

        [JsonPropertyName("TglKeputusanKlaim")]
        public DateTime? tgl_keputusan_klaim { get; set; }

        [JsonPropertyName("JumlahTerjamin")]
        public int? jumlah_terjamin { get; set; }

        [JsonPropertyName("NilaiBebanKlaim")]
        public string? nilai_beban_klaim { get; set; }

        [JsonPropertyName("DebitKredit")]
        public string? debet_kredit { get; set; }

    }




}
