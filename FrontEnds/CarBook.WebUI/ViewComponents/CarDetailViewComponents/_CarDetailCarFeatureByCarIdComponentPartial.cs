using CarBook.Dto.CarFeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.CarDetailViewComponents
{
	public class _CarDetailCarFeatureByCarIdComponentPartial :ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _CarDetailCarFeatureByCarIdComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}


		[Route("Index/{id}")]
		[HttpGet]
		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			ViewBag.carID = id;
			var client = _httpClientFactory.CreateClient();
			var responseMsg = await client.GetAsync("https://localhost:7039/api/CarFeatures?id=" + id);
			if (responseMsg.IsSuccessStatusCode)
			{
				var jsonData = await responseMsg.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultCarFeatureByCarIdDto>>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}
