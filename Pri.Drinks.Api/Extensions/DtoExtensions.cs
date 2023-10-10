﻿using Pri.Drinks.Api.DTOs;
using Pri.Drinks.Api.DTOs.Response;
using Pri.Drinks.Core.Entities;

namespace Pri.Drinks.Api.Extensions
{
    public static class DtoExtensions
    {
        //map from entity to dto
        public static void MapToDto
            (this DrinksGetByIdDto drinksGetByIdDto, Drink drink)
        {
            drinksGetByIdDto.Id = drink.Id;
            drinksGetByIdDto.Name = drink.Name; 
            drinksGetByIdDto.AlcoholPercentage = drink.AlcoholPercentage;
            drinksGetByIdDto.Category = new BaseDto
            {
                Id = drink.Category.Id,
                Name = drink.Category.Name,
            };
            drinksGetByIdDto.Properties
                = drink.Properties.Select(p =>
                new BaseDto
                {
                    Id = p.Id,
                    Name = p.Name,
                });
        }
        public static void MapToDto(this DrinksGetAllDto drinksGetAllDto, IEnumerable<Drink> drinks)
        {
            var drinksGetByIdDto = new DrinksGetByIdDto();
            drinksGetAllDto.Drinks = drinks.Select(d =>
            {
                drinksGetByIdDto.MapToDto(d);
                return drinksGetByIdDto;
            });
            //less performance
            //var drinksDtoList = new List<DrinksGetByIdDto>();
            //foreach (var drink in drinks)
            //{
            //    var drinksGetByIdDto = new DrinksGetByIdDto();
            //    drinksGetByIdDto.MapToDto(drink);
            //    drinksDtoList.Add(drinksGetByIdDto);
            //}
            //drinksGetAllDto.Drinks = drinksDtoList;
        }
        //Map from entity class to dto
        public static DrinksGetByIdDto MapToDto(this Drink drink)
        {
            return new DrinksGetByIdDto
            {
                Id = drink.Id,
                Name = drink.Name,
                AlcoholPercentage = drink.AlcoholPercentage,
                Properties = drink.Properties.Select(p => new BaseDto
                {
                    Id = p.Id,
                    Name = p.Name,
                }),
                Category = new BaseDto
                {
                    Id = drink.Category.Id,
                    Name = drink.Category.Name,
                }
            };
        }
    }
}
