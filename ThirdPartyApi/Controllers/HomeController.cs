using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ThirdPartyApi.Models;
using ThirdPartyApi.Services;

namespace ThirdPartyApi.Controllers
{
    public class HomeController : Controller
    {
        private readonly IApiService _apiService;

        // private readonly ILogger<HomeController> _logger;

        public HomeController(IApiService apiService)
        {
            _apiService = apiService;
            //_logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            List<PredictionModel> predictions = new List<PredictionModel>();
            predictions = await _apiService.GetPredictions();

            return View(predictions);
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}

        //public IActionResult Privacy()
        //{
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
