using Entities.Models.DbAplikasi;
using Azure.Core;
using Components.Repositories;
using Helpers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;
using Entities.Response.LOB;
using Entities.Models.DbPenampung;

namespace Repositories.Master
{
    public class ICApiRepository : IApiRepository
    {
        private readonly dbaplikasi_context _context;
        private readonly dbpenampung_context _contextPenampung;
        public ICApiRepository(dbaplikasi_context context, dbpenampung_context contextPenampung)
        {
            _context = context;
            _contextPenampung = contextPenampung;
        }

        public async Task<(bool status, int statusCode, string message, List<ResponseViewKlaimPerLOB> data, List<ResponseCountKlaimPerLOB> count)> ViewRepository()
        {
            try
            {
                var result = await StoredProcedureExecutor.ExecuteSPListAsync<ResponseViewKlaimPerLOB>
                      (_context, "[Sp_ViewKlamPerLOB]", new SqlParameter[] {});

                var count = await StoredProcedureExecutor.ExecuteSPListAsync<ResponseCountKlaimPerLOB>
                     (_context, "[Sp_CountViewKlamPerLOB]", new SqlParameter[] { });

                if (result == null)
                {
                    return (false, StatusResponse.OK, "not found", null, null);
                }

                return (true, StatusResponse.OK, "success", result, count);


            }
            catch (SqlException ex) when (ex.Number == -2)
            {
                return (false, StatusResponse.InternalServerError, "Timeout request", null, null);
            }
            catch (Exception ex)
            {
                return (false, StatusResponse.InternalServerError, ex.ToString() == null ? ex.InnerException.Message : ex.ToString(), null, null);
            }
        }

        public async Task<(bool status, int statusCode, string message)> SendDataRepository()
        {
            try
            {
                var result = await StoredProcedureExecutor.ExecuteSPListAsync<ResponseDataKlaimKurPen>
                      (_context, "[Sp_DataKlaimKurPen]", new SqlParameter[] { });

                if (result == null)
                {
                    return (false, StatusResponse.OK, "not found");
                }


                var listAdd = new List<TblKlaimLobKurPen>();

                foreach (var item in result)
                {
                    var add = new TblKlaimLobKurPen()
                    {
                        SubCob = item.name_lob,
                        PenyebabKlaim = item.penyebab_klaim,
                        Periode = item.periode,
                        NamaWilker = item.nama_wilker,
                        TglKeputusanKlaim = item.tgl_keputusan_klaim,
                        JumlahTerjamin = item.jumlah_terjamin,
                        NilaiBebanKlaim = item.nilai_beban_klaim,
                        DebetKredit = item.debet_kredit,
                    };

                    listAdd.Add(add);
                }

                await _contextPenampung.AddRangeAsync(listAdd);
                await _contextPenampung.SaveChangesAsync();

                var logActivity = new TblLogActivity()
                {
                    JumlahData = result.Count(),
                    Status = "done",
                    CreatedAt = DateTime.Now,
                };

                await _contextPenampung.AddAsync(logActivity);
                await _contextPenampung.SaveChangesAsync();

               

                return (true, StatusResponse.OK, "success");


            }
            catch (SqlException ex) when (ex.Number == -2)
            {
                return (false, StatusResponse.InternalServerError, "Timeout request");
            }
            catch (Exception ex)
            {
                return (false, StatusResponse.InternalServerError, ex.ToString() == null ? ex.InnerException.Message : ex.ToString());
            }
        }

        public async Task<(bool status, int statusCode, string message)> RekapRepository()
        {
            try
            {
                var result = await StoredProcedureExecutor.ExecuteSPListAsync<ResponseRekapLOB>
                      (_context, "[Sp_RekapLOB]", new SqlParameter[] { });

                var listAdd = new List<TblIntegrasi>();

                foreach (var item in result)
                {
                    var add = new TblIntegrasi()
                    {
                        NameLob = item.name_lob,
                        PenyebabKlaim = item.penyebab_klaim,
                        Periode = item.periode,
                        NilaiBebanKlaim = item.nilai_beban_klaim,
                        CreatedAt = DateTime.Now,
                    };

                    listAdd.Add(add);
                }

                await _contextPenampung.AddRangeAsync(listAdd);
                await _contextPenampung.SaveChangesAsync();

                if (result == null)
                {
                    return (false, StatusResponse.OK, "not found");
                }

                return (true, StatusResponse.OK, "success");


            }
            catch (SqlException ex) when (ex.Number == -2)
            {
                return (false, StatusResponse.InternalServerError, "Timeout request");
            }
            catch (Exception ex)
            {
                return (false, StatusResponse.InternalServerError, ex.ToString() == null ? ex.InnerException.Message : ex.ToString());
            }
        }



    }

        
}

