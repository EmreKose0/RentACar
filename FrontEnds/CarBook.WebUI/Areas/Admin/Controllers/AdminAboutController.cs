using CarBook.Dto.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook.WebUI.Areas.Admin.Controllers
{
        [Area("Admin")]
        [Route("Admin/AdminAbout")]
        public class AdminAboutController : Controller
        {
            private readonly IHttpClientFactory _httpClientFactory;

            public AdminAboutController(IHttpClientFactory httpClientFactory)
            {
                _httpClientFactory = httpClientFactory;
            }
            [Route("Index")]
            public async Task<IActionResult> Index()
            {
                var client = _httpClientFactory.CreateClient();
                var responseMsg = await client.GetAsync("https://localhost:7039/api/Abouts");
                if (responseMsg.IsSuccessStatusCode)
                {
                    var jsonData = await responseMsg.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                    return View(values);
                }
                return View();
            }
            [HttpGet]
            [Route("CreateAbout")]
            public IActionResult CreateAbout()

            {
                return View();
            }

            [HttpPost]
            [Route("CreateAbout")]
            public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createAboutDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMsg = await client.PostAsync("https://localhost:7039/api/Abouts", stringContent);
                if (responseMsg.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "AdminAbout", new { area = "Admin" });
                }
                return View();
            }

            [Route("RemoveAbout/{id}")]
            public async Task<IActionResult> RemoveAbout(int id)
            {
                var client = _httpClientFactory.CreateClient();
                var responseMsg = await client.DeleteAsync($"https://localhost:7039/api/Abouts?id=" + id);
                if (responseMsg.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "AdminAbout", new { area = "Admin" });
                }
                return View();

            }

            [HttpGet]
            [Route("UpdateAbout/{id}")]
            public async Task<IActionResult> UpdateAbout(int id)
            {
                var client = _httpClientFactory.CreateClient();
                var responseMsg = await client.GetAsync($"https://localhost:7039/api/Abouts/{id}");
                if (responseMsg.IsSuccessStatusCode)
                {
                    var jsonData = await responseMsg.Content.ReadAsStringAsync();
                    var values = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
                    return View(values);
                }
                return View();
            }

            [HttpPost]
            [Route("UpdateAbout/{id}")]
            public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(updateAboutDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMsg = await client.PutAsync("https://localhost:7039/api/Abouts/", stringContent);
                if (responseMsg.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "AdminAbout", new { area = "Admin" });
                }
            return View();
    
            }
        }
}
