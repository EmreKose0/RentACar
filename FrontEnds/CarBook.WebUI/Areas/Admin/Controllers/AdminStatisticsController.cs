using CarBook.Dto.AuthorDtos;
using CarBook.Dto.StatisticDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistics")]
    public class AdminStatisticsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            #region CarCount 
            
            var random = new Random();
            var client = _httpClientFactory.CreateClient();
            var responseMsg = await client.GetAsync("https://localhost:7039/api/Statistics/GetCarCount");
            if (responseMsg.IsSuccessStatusCode)
            {
                var v1 = random.Next(0,100);
                var jsonData = await responseMsg.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.v1 = values.carCount;
                ViewBag.v11 = v1;
            }
            #endregion

            #region LocationCount 

            var responseMsg2 = await client.GetAsync("https://localhost:7039/api/Statistics/GetLocationCount");
            if (responseMsg2.IsSuccessStatusCode)
            { 
                var v2 = random.Next(0, 100);
                var jsonData2 = await responseMsg2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData2);
                ViewBag.v2 = values2.locationCount;
                ViewBag.v22 = v2;
            }
            #endregion

            #region AuthorCount
            var responseMsg3 = await client.GetAsync("https://localhost:7039/api/Statistics/GetAuthorCount");
            if (responseMsg3.IsSuccessStatusCode)
            {
                var v3 = random.Next(0, 100);
                var jsonData3 = await responseMsg3.Content.ReadAsStringAsync();
                var values3 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData3);
                ViewBag.v3 = values3.authorCount;
                ViewBag.v33 = v3;
            }
            #endregion

            #region BlogCount
            var responseMsg4 = await client.GetAsync("https://localhost:7039/api/Statistics/GetBlogCount");
            if (responseMsg4.IsSuccessStatusCode)
            {
                var v4 = random.Next(0, 100);
                var jsonData4 = await responseMsg4.Content.ReadAsStringAsync();
                var values4 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData4);
                ViewBag.v4 = values4.blogCount;
                ViewBag.v44 = v4;
            }
            #endregion

            #region BrandCpunt
            var responseMsg5 = await client.GetAsync("https://localhost:7039/api/Statistics/GetBrandCount");
            if (responseMsg5.IsSuccessStatusCode)
            {
                var v5 = random.Next(0, 100);
                var jsonData5 = await responseMsg5.Content.ReadAsStringAsync();
                var values5 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData5);
                ViewBag.v5 = values5.brandCount;
                ViewBag.v55 = v5;
            }
            #endregion

            #region GetAvgRentPriceForDaily
            var responseMsg6 = await client.GetAsync("https://localhost:7039/api/Statistics/GetAvgRentPriceForDaily");
            if (responseMsg6.IsSuccessStatusCode)
            {
                var v6 = random.Next(0, 100);
                var jsonData6 = await responseMsg6.Content.ReadAsStringAsync();
                var values6 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData6);
                ViewBag.v6 = values6.avgRentPriceForDaily.ToString("0,00");
                ViewBag.v66 = v6;
            }
            #endregion

            #region GetAvgRentPriceForWeekly
            var responseMsg7 = await client.GetAsync("https://localhost:7039/api/Statistics/GetAvgRentPriceForWeekly");
            if (responseMsg7.IsSuccessStatusCode)
            {
                var v7 = random.Next(0, 100);
                var jsonData7 = await responseMsg7.Content.ReadAsStringAsync();
                var values7 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData7);
                ViewBag.v7 = values7.avgRentPriceForWeekly.ToString("0,00");
                ViewBag.v77 = v7;
            }
            #endregion

            #region GetAvgRentPriceForMonthly
            var responseMsg8 = await client.GetAsync("https://localhost:7039/api/Statistics/GetAvgRentPriceForMonthly");
            if (responseMsg8.IsSuccessStatusCode)
            {
                var v8 = random.Next(0, 100);
                var jsonData8 = await responseMsg8.Content.ReadAsStringAsync();
                var values8 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData8);
                ViewBag.v8 = values8.avgRentPriceForMonthly.ToString("0,00");
                ViewBag.v88 = v8;
            }
            #endregion

            #region GetCarCountByTransmissionIsAuto
            var responseMsg9 = await client.GetAsync("https://localhost:7039/api/Statistics/GetCarCountByTransmissionIsAuto");
            if (responseMsg9.IsSuccessStatusCode)
            {
                var v9 = random.Next(0, 100);
                var jsonData9 = await responseMsg9.Content.ReadAsStringAsync();
                var values9 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData9);
                ViewBag.v9 = values9.carCountByTransmissionIsAuto;
                ViewBag.v99 = v9;
            }
            #endregion

            #region GetBrandNameByMaxCar
            var responseMsg10 = await client.GetAsync("https://localhost:7039/api/Statistics/GetBrandNameByMaxCar");
            if (responseMsg10.IsSuccessStatusCode)
            {
                var v10 = random.Next(0, 100);
                var jsonData10 = await responseMsg10.Content.ReadAsStringAsync();
                var values10 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData10);
                ViewBag.v10 = values10.brandNameByMaxCar;
                ViewBag.v100 = v10;
            }
            #endregion

            #region GetCarCountByKmUnder1000
            var responseMsg111 = await client.GetAsync("https://localhost:7039/api/Statistics/GetCarCountByKmUnder1000");
            if (responseMsg111.IsSuccessStatusCode)
            {
                var v111 = random.Next(0, 100);
                var jsonData111 = await responseMsg111.Content.ReadAsStringAsync();
                var values111 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData111);
                ViewBag.v111 = values111.carCountByKmUnder1000;
                ViewBag.v101 = v111;
            }
            #endregion

            #region GetCarCountByFuelGasOrDiesel
            var responseMsg112 = await client.GetAsync("https://localhost:7039/api/Statistics/GetCarCountByFuelGasOrDiesel");
            if (responseMsg112.IsSuccessStatusCode)
            {
                var v112 = random.Next(0, 100);
                var jsonData112 = await responseMsg112.Content.ReadAsStringAsync();
                var values112 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData112);
                ViewBag.v112 = values112.carCountByFuelGasOrDiesel;
                ViewBag.v102 = v112;
            }
            #endregion

            #region GetCarCountByFuelElectric
            var responseMsg113 = await client.GetAsync("https://localhost:7039/api/Statistics/GetCarCountByFuelElectric");
            if (responseMsg113.IsSuccessStatusCode)
            {
                var v113 = random.Next(0, 100);
                var jsonData113 = await responseMsg113.Content.ReadAsStringAsync();
                var values113 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData113);
                ViewBag.v113 = values113.carCountByFuelElectric;
                ViewBag.v103 = v113;
            }
            #endregion

            #region GetCarBrandAndModelByRentPriceMax
            var responseMsg114 = await client.GetAsync("https://localhost:7039/api/Statistics/GetCarBrandAndModelByRentPriceMax");
            if (responseMsg114.IsSuccessStatusCode)
            {
                var v114 = random.Next(0, 100);
                var jsonData114 = await responseMsg114.Content.ReadAsStringAsync();
                var values114 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData114);
                ViewBag.v114 = values114.carBrandAndModelByRentPriceMax;
                ViewBag.v104 = v114;
            }
            #endregion

            #region GetCarBrandAndModelByRentPriceMin
            var responseMsg115 = await client.GetAsync("https://localhost:7039/api/Statistics/GetCarBrandAndModelByRentPriceMin");
            if (responseMsg115.IsSuccessStatusCode)
            {
                var v115 = random.Next(0, 100);
                var jsonData115 = await responseMsg115.Content.ReadAsStringAsync();
                var values115 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData115);
                ViewBag.v115 = values115.carBrandAndModelByRentPriceMin;
                ViewBag.v105 = v115;
            }
            #endregion

            #region GetBlogTitleByMaxBlogComment
            var responseMsg116 = await client.GetAsync("https://localhost:7039/api/Statistics/GetBlogTitleByMaxBlogComment");
            if (responseMsg116.IsSuccessStatusCode)
            {
                var v116 = random.Next(0, 100);
                var jsonData116 = await responseMsg116.Content.ReadAsStringAsync();
                var values116 = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData116);
                ViewBag.v116 = values116.blogTitleByMaxBlogComment;
                ViewBag.v106 = v116;
            }
            #endregion




            return View();
        }
    }
}
