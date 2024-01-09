using CarBook.Dto.StatisticsDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminStatisticController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {

            ViewBag.carCount = await GetValueAsync("GetCarCount");
            ViewBag.locationCount = await GetValueAsync("GetLocationCount");
            ViewBag.authorCount = await GetValueAsync("GetAuthorCount");
            ViewBag.blogCount = await GetValueAsync("GetBlogCount");
            ViewBag.brandCount = await GetValueAsync("GetBrandCount");
            ViewBag.avgRentPriceForDailyCount = await GetValueAsync("GetAvgRentPriceForDaily");
            ViewBag.avgRentPriceForWeekly = await GetValueAsync("GetAvgRentPriceForWeekly");
            ViewBag.avgRentPriceForMonthly = await GetValueAsync("GetAvgRentPriceForMonthly");
            ViewBag.carCountByTranmissionIsAuto = await GetValueAsync("GetCarCountByTranmissionIsAuto");
            ViewBag.carCountByKmSmallerThen1000 = await GetValueAsync("GetCarCountByKmSmallerThen1000");
            ViewBag.carCountByFuelElectric = await GetValueAsync("GetCarCountByFuelElectric");
            ViewBag.carBrandAndModelByRentPriceDailyMax = await GetValueAsync("GetCarBrandAndModelByRentPriceDailyMax");
            ViewBag.carBrandAndModelByRentPriceDailyMin = await GetValueAsync("GetCarBrandAndModelByRentPriceDailyMin");
            ViewBag.brandNameByMaxCar = await GetValueAsync("GetBrandNameByMaxCar");
            ViewBag.blogTitleByMaxBlogComment = await GetValueAsync("GetBlogTitleByMaxBlogComment");

            (ViewBag.gasolineCount, ViewBag.dieselCount) = await Get2ValueAsync("GetCarCountByFuelGasolineOrDiesel");
            return View();
        }


        public async Task<object> GetValueAsync(string url)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7177/api/Statistic/{url}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData)!;
                if (url == "GetCarCount") return Convert.ToInt32(values.carCount);
                if (url == "GetLocationCount") return Convert.ToInt32(values.locationCount);
                if (url == "GetAuthorCount") return Convert.ToInt32(values.authorCount);
                if (url == "GetBlogCount") return Convert.ToInt32(values.blogCount);
                if (url == "GetBrandCount") return Convert.ToInt32(values.brandCount);
                if (url == "GetAvgRentPriceForDaily") return Convert.ToDecimal(values.avgPriceForDaily);
                if (url == "GetAvgRentPriceForWeekly") return Convert.ToDecimal(values.avgPriceForWeekly);
                if (url == "GetAvgRentPriceForMonthly") return Convert.ToDecimal(values.avgRentPriceForMonthly);
                if (url == "GetCarCountByTranmissionIsAuto") return Convert.ToInt32(values.carCountByTranmissionIsAuto);
                if (url == "GetCarCountByKmSmallerThen1000") return Convert.ToInt32(values.carCountByKmSmallerThen1000);
                if (url == "GetCarCountByFuelElectric") return Convert.ToInt32(values.carCountByFuelElectric);
                if (url == "GetCarBrandAndModelByRentPriceDailyMax") return values.carBrandAndModelByRentPriceDailyMax;
                if (url == "GetCarBrandAndModelByRentPriceDailyMin") return values.carBrandAndModelByRentPriceDailyMin;
                if (url == "GetBrandNameByMaxCar") return values.brandNameByMaxCar;
                if (url == "GetBlogTitleByMaxBlogComment") return values.blogTitleByMaxBlogComment;

            }

            return 0;
        }

        public async Task<Tuple<int, int>> Get2ValueAsync(string url)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7177/api/Statistic/{url}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData)!;
                if (url == "GetCarCountByFuelGasolineOrDiesel")
                {
                    var _gasolineCount = values.gasolineCount;
                    var _dieselCount = values.dieselCount;
                    return new Tuple<int, int>(_gasolineCount, _dieselCount);
                }
            }
            return new Tuple<int, int>(0, 0);
        }
    }
}
