﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pri.Drinks.Api.DTOs;
using Pri.Drinks.Api.DTOs.Request;
using Pri.Drinks.Api.DTOs.Response;
using Pri.Drinks.Api.Extensions;
using Pri.Drinks.Core.Interfaces.Services;

namespace Pri.Drinks.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DrinksController : ControllerBase
    {
        private readonly IDrinkService _drinkService;

        public DrinksController(IDrinkService drinkService)
        {
            _drinkService = drinkService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll() 
        {
            var result = await _drinkService.GetAllAsync();
            var drinksGetallDto = new DrinksGetAllDto();
            drinksGetallDto.MapToDto(result.Items);
            
            return Ok(drinksGetallDto);
        }
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            //get the drink
            var result = await _drinkService
                .GetByIdAsync(id);
            //check result
            if(!result.IsSuccess)
            {
                return NotFound(result.Errors);
            }
            //fill the dto
            var drinksGetByIdDto = new DrinksGetByIdDto();
            drinksGetByIdDto.MapToDto(result.Items.First());
            
            //return to client
            return Ok(drinksGetByIdDto);
        }
        [HttpGet("{name}")]
        public async Task<IActionResult> SearchByName(string name)
        {
            //get the drinks based on search
            var result = await _drinkService.SearchByNameAsync(name);
            //return a dto
            return Ok(new DrinksSearchByNameDto 
            {
                Drinks = result.Items.Select(d => new DrinksGetByIdDto 
                {
                    Id = d.Id,
                    Name = d.Name,
                    Category = new BaseDto
                    {
                        Id = d.Category.Id,
                        Name = d.Category.Name,
                    },
                    Properties = d.Properties
                    .Select(p => new BaseDto
                    {
                        Id = p.Id,
                        Name = p.Name,
                    }),
                })
            });
        }
        [HttpPost]
        public async Task<IActionResult> Create(DrinksCreateDto drinksCreateDto)
        {
            var result = await _drinkService
                .CreateAsync(drinksCreateDto.Name,
                drinksCreateDto.CategoryId,
                drinksCreateDto.AlcoholPercentage,
                drinksCreateDto.PropertyIds);
            if(!result.IsSuccess)
            {
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
                return BadRequest(ModelState.Values);
            }
            return Ok("Created");
        }
        [HttpPut]
        public async Task<IActionResult> Update(DrinksUpdateDto drinksUpdateDto)
        {
            if(!await _drinkService.ExistsAsync(drinksUpdateDto.Id))
            {
                return NotFound();
            };
            var result = await _drinkService.UpdateAsync(
                drinksUpdateDto.Id,
                drinksUpdateDto.Name,
                drinksUpdateDto.CategoryId,
                drinksUpdateDto.AlcoholPercentage,
                drinksUpdateDto.PropertyIds
                );
            if (!result.IsSuccess)
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error);
                }
                return BadRequest(ModelState.Values);
            }
            return Ok("Updated");
        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            if(!await  _drinkService.ExistsAsync(id))
            {
                return NotFound();
            }
            var result = await _drinkService.DeleteAsync(id);
            if(!result.IsSuccess)
            {
                return BadRequest(result.Errors);
            }
            return Ok("Deleted");
        }
    }
}
