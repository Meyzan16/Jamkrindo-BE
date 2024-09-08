using Entities.Response;
using Entities.Response.LOB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IApiService
    {
        Task<ListResponse<ResponseData>> View();
        Task<ListResponse<ResponseData>> SendData();
        Task<ListResponse<ResponseData>> Rekap();
    }

