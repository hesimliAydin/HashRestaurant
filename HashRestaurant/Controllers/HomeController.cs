﻿using HashRestaurant.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using HashRestaurant.Repositories;
using System.Threading.Tasks;

namespace HashRestaurant.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Hotmeals(int id = -1)
        {
            if (id == -1)
            {
                var vm = new HotMealsViewModel();
                vm.Hotmeals = FakeRepo.GetHotMeals();
                return View(vm);
            }
            var hotmeal = FakeRepo.GetHotMeals().SingleOrDefault(h => h.Id == id);
            
            return View("ItemView", hotmeal);
        }

        public IActionResult Drinks(int id = -1)
        {
            if (id == -1)
            {
                var vm = new DrinksViewModel();
                vm.Drinks = FakeRepo.GetDrinks();
                return View(vm);
            }
            var drink = FakeRepo.GetDrinks().SingleOrDefault(d => d.Id == id);
            
            return View("ItemView", drink);
        }

        public IActionResult Fastfoods(int id = -1)
        {
            if (id == -1)
            {
                var vm = new FastFoodsViewModel();
                vm.Fastfoods = FakeRepo.GetFastFoods();
                return View(vm);
            }
            var fastfood = FakeRepo.GetFastFoods().SingleOrDefault(d => d.Id == id);

            return View("ItemView", fastfood);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
