using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Default
{
    public class _AboutUsPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _AboutUsPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            //Consume edilmesi için bir istemci oluşturduk.
            var client = _httpClientFactory.CreateClient();
            //Bu adrese bir istekte bulunduk
            var responseMessage = await client.GetAsync("http://localhost:5287/api/About");
            if (responseMessage.IsSuccessStatusCode)
            {
                //gelen veriyi jsonData'ya atadık jsonData türünde
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //Deserialize ederek tabloda gösterecek formata dönüştürdük
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }
            return View();
            
        }
    }
}
