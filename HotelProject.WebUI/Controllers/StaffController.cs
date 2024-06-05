using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.Controllers
{
    public class StaffController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public StaffController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            //Consume edilmesi için bir istemci oluşturduk.
            var client = _httpClientFactory.CreateClient();
            //Bu adrese bir istekte bulunduk
            var responseMessage = await client.GetAsync("http://localhost:5287/api/Staff");
            if (responseMessage.IsSuccessStatusCode)
            {
                //gelen veriyi jsonData'ya atadık jsonData türünde
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //Deserialize ederek tabloda gösterecek formata dönüştürdük
                var values = JsonConvert.DeserializeObject<List<StaffViewModel>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}
