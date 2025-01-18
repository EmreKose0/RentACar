﻿using Microsoft.AspNetCore.SignalR;

namespace CarBook.WebApi.Hubs
{
    public class CarHub :Hub
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CarHub(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task SendCarCount()
        {
            var client = _httpClientFactory.CreateClient();        
            var responseMsg = await client.GetAsync("https://localhost:7039/api/Statistics/GetCarCount");           
            var value = await responseMsg.Content.ReadAsStringAsync();
            await Clients.All.SendAsync("ReceiveCarCount", value);            
        }
    }
}
