using CarBook.Dto.CarDtos;
using CarBook.Dto.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBook.WebUI.ViewComponents.CarDetailViewComponents
{
	public class _CarDetailMainFeatureComponentPartial :ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _CarDetailMainFeatureComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			ViewBag.carID = id;
			var client = _httpClientFactory.CreateClient();
			var responseMsg = await client.GetAsync($"https://localhost:7039/api/Cars/{id}");
			if (responseMsg.IsSuccessStatusCode)
			{
				var jsonData = await responseMsg.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ResultCarWithBrandsDtos>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
