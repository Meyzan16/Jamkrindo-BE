using Azure.Core;
using Components;
using Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Response;
using Entities.Response.LOB;

namespace Services
{
    public class ApiService : IApiService
    {
        private readonly IRepositoriesManager _repositoryManager;
        public ApiService( IRepositoriesManager repositoryManager)
        {
             _repositoryManager = repositoryManager;
        }

        public async Task<ListResponse<ResponseData>> View()
        {
            var result = await _repositoryManager.ICApiRepository.ViewRepository();

            if (result.status == false)
            {
                return new ListResponse<ResponseData> { Code = StatusResponse.InternalServerError, Message = result.message, Data = null };

            }

            // Mengisi Data dengan benar
            return new ListResponse<ResponseData>
            {
                Code = StatusResponse.OK,
                Message = result.message,
                Data = new List<ResponseData>
                {
                    new ResponseData
                    {
                        ResponseViewKlaimPerLOB = result.data,
                        ResponseCountKlaimPerLOB = result.count
                    }
                }
            };
        }

        public async Task<ListResponse<ResponseData>> SendData()
        {
            var result = await _repositoryManager.ICApiRepository.SendDataRepository();

            if (result.status == false)
            {
                return new ListResponse<ResponseData> { Code = StatusResponse.InternalServerError, Message = result.message, Data = null };

            }

            // Mengisi Data dengan benar
            return new ListResponse<ResponseData>
            {
                Code = StatusResponse.NoContent,
                Message = result.message,
                Data = null
            };
        }

        public async Task<ListResponse<ResponseData>> Rekap()
        {
            var result = await _repositoryManager.ICApiRepository.RekapRepository();

            if (result.status == false)
            {
                return new ListResponse<ResponseData> { Code = StatusResponse.InternalServerError, Message = result.message, Data = null };

            }

            // Mengisi Data dengan benar
            return new ListResponse<ResponseData>
            {
                Code = StatusResponse.NoContent,
                Message = result.message,
                Data = null
            };
        }


    }
}
