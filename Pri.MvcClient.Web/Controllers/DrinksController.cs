using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Pri.MvcClient.Web.ViewModels;

namespace Pri.MvcClient.Web.Controllers
{
    public class DrinksController : Controller
    {
        private readonly HttpClient _httpClient;

        public DrinksController()
        {
            _httpClient = new HttpClient();
        }
        public async Task<IActionResult> Index()
        {
            var url = new Uri("https://localhost:7295/api/Drinks");
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
            var url = new Uri($"https://localhost:7295/api/Drinks/{id}");
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
