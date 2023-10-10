using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pri.MvcClient.Web.ViewModels;

namespace Pri.MvcClient.Web.Controllers
{
    public class DrinksController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _baseUrl;

        public DrinksController(IConfiguration configuration)
        {
            _httpClient = new HttpClient();
            _configuration = configuration;
            _baseUrl = $"{_configuration.GetSection("ApiUrl:BaseUrl").Value}/Drinks";
        }
        public async Task<IActionResult> Index()
        {
            var url = new Uri(_baseUrl);
            var result = await _httpClient.GetAsync(url);
            if(!result.IsSuccessStatusCode)
            {
                return BadRequest("Error");
            }
            var content = await result.Content.ReadAsStringAsync();
            var drinksIndexViewModel = JsonConvert.DeserializeObject
                <DrinksIndexViewModel>(content);
            return View(drinksIndexViewModel);
        }
        public async Task<IActionResult> Get(int id)
        {
            var url = new Uri($"{_baseUrl}/{id}");
            var result = await _httpClient.GetAsync(url);
            if(!result.IsSuccessStatusCode)
            {
                return NotFound();
            }
            //read the content to serialized string
            var content = await result.Content.ReadAsStringAsync();
            //deserialize json string to object of type DrinksGetViewModel
            var drinksGetViewModel =
                JsonConvert.DeserializeObject<DrinksGetViewModel>(content);
            return View(drinksGetViewModel);
        }
    }
}
