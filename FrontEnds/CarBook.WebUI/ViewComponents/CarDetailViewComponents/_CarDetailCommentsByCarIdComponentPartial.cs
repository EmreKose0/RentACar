using CarBook.Dto.CarFeatureDtos;
using CarBook.Dto.ReviewDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Newtonsoft.Json;
using System.Net.Http;

namespace CarBook.WebUI.ViewComponents.CarDetailViewComponents
{
	public class _CarDetailCommentsByCarIdComponentPartial :ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _CarDetailCommentsByCarIdComponentPartial(IHttpClientFactory httpCLientFactory)
		{
			_httpClientFactory = httpCLientFactory;
		}
		
		
		
		[HttpGet]
		public async Task<IViewComponentResult> InvokeAsync(int id)
		
		{
			ViewBag.carID = id;
			var client = _httpClientFactory.CreateClient();
			var responseMsg = await client.GetAsync("https://localhost:7039/api/Reviews?Id=" + id);
			if (responseMsg.IsSuccessStatusCode) 
			{
				var jsonData = await responseMsg.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultReviewDto>>(jsonData);
				return View(values);

			}
			return View();
		}
	}
}
