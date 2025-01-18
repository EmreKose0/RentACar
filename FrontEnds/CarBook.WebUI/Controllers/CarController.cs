using CarBook.Dto.CarDtos;
using CarBook.Dto.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.Controllers
{
    public class CarController : Controller
    {
        private readonly IHttpClientFactory _httpclientFactory;

        public CarController(IHttpClientFactory httpclientFactory)
        {
            _httpclientFactory = httpclientFactory;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.v1 = "Araçlar";
            ViewBag.v2 = "Aracınızı Seçiniz";
            var client = _httpclientFactory.CreateClient();
            var responsemsg = await client.GetAsync("https://localhost:7039/api/CarPricings");
            if (responsemsg.IsSuccessStatusCode)
            {
                var jsonData = await responsemsg.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingWithCarDto>>(jsonData);
                return View(values);
            }
            return View();
        }

        public async Task<IActionResult> CarDetail(int id)
        {
            ViewBag.v1 = "Araç Detayları";
            ViewBag.v2 = "Aracın Teknik Özellikleri";
            ViewBag.carID = id;
            return View();
        }
    }
}
