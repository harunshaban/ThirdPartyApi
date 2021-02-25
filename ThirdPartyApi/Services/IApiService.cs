using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ThirdPartyApi.Models;

namespace ThirdPartyApi.Services
{
    public interface IApiService
    {
        Task<List<PredictionModel>> GetPredictions();
    }
}
