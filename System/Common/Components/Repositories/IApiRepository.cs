using Entities.Response.LOB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Components.Repositories
{
    public interface IApiRepository
    {
        Task<(bool status, int statusCode, string message, List<ResponseViewKlaimPerLOB> data, List<ResponseCountKlaimPerLOB> count)> ViewRepository();
        Task<(bool status, int statusCode, string message)> SendDataRepository();
        Task<(bool status, int statusCode, string message)> RekapRepository();
    }
}
