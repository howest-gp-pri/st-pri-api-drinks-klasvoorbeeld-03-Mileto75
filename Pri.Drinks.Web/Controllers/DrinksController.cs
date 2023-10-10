using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pri.Drinks.Core.Interfaces.Repositories;
using Pri.Drinks.Core.Interfaces.Services;
using Pri.Drinks.Infrastructure.Data;
using Pri.Drinks.Web.Models;
using Pri.Drinks.Web.ViewModels;

namespace Pri.Drinks.Web.Controllers
{
    public class DrinksController : Controller
    {
        private readonly IDrinkService _drinkService;

        public DrinksController(IDrinkService drinkService)
        {
            _drinkService = drinkService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _drinkService.GetAllAsync();
            if(!result.IsSuccess)
            {
                return View("Error", new ErrorViewModel {Errors = result.Errors });
            }
            var drinksIndexViewModel = new DrinksIndexViewModel
            {
                Drinks = result.Items
                .Select(d => new BaseViewModel
                {
                    Id = d.Id, Name = d.Name
                })
            };
            return View(drinksIndexViewModel);
        }
        public async Task<IActionResult> Info(int id)
        {
            var result = await _drinkService
                .GetByIdAsync(id);
            if(!result.IsSuccess) 
            {
                return NotFound();
            }
            var drinksInfoViewModel = new DrinksInfoViewModel 
            {
                Id= result.Items.First().Id,
                Name = result.Items.First().Name,
                Properties = result.Items.First().Properties.Select(p => new BaseViewModel { Id = p.Id, Name = p.Name }),
                Category = new BaseViewModel { Id = result.Items.First().Category.Id,Name = result.Items.First().Category.Name},
                AlcoholPercentage = result.Items.First().AlcoholPercentage
            };
            return View(drinksInfoViewModel);
        }
    }
}
