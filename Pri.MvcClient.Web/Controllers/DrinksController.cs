using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Pri.MvcClient.Web.Models;
using Pri.MvcClient.Web.ViewModels;
using System.Text;

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
        [HttpGet]
        public async Task<IActionResult> Add()
        {
            //get the categories
            var categoryUrl = new Uri($"{_baseUrl}/categories");
            var result = await _httpClient.GetAsync(categoryUrl);
            var content = await result.Content.ReadAsStringAsync();
            var categories = JsonConvert
                .DeserializeObject<BaseItemsViewModel>(content);
            //get the properties
            var propertyUrl = new Uri($"{_baseUrl}/properties");
            result = await _httpClient.GetAsync(propertyUrl);
            content = await result.Content.ReadAsStringAsync();
            var properties = JsonConvert.DeserializeObject<BaseItemsViewModel>(content);
            //populate form data properties and categories
            //create the model
            var drinksAddViewModel = new DrinksAddViewModel
            {
                Properties = properties.Items.Select(i =>
                new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                Categories = categories.Items.Select(i =>
                new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
            };
            //pass tot the view
            return View(drinksAddViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Add(DrinksAddViewModel drinksAddViewModel)
        {
            //get the categories
            var categoryUrl = new Uri($"{_baseUrl}/categories");
            var result = await _httpClient.GetAsync(categoryUrl);
            var content = await result.Content.ReadAsStringAsync();
            var categories = JsonConvert
                .DeserializeObject<BaseItemsViewModel>(content);
            //get the properties
            var propertyUrl = new Uri($"{_baseUrl}/properties");
            result = await _httpClient.GetAsync(propertyUrl);
            content = await result.Content.ReadAsStringAsync();
            var properties = JsonConvert.DeserializeObject<BaseItemsViewModel>(content);
            //modelstate error
            if (!ModelState.IsValid)
            {
                drinksAddViewModel.Properties = properties.Items.Select(i =>
                new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
                drinksAddViewModel.Categories = categories.Items.Select(i =>
                new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                });
                return View(drinksAddViewModel);
            }
            
            return View(drinksAddViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            return RedirectToAction("Error", "Home");
        }
    
    }
}
